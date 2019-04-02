import axios from 'axios'
import store from '@/store'
import Vue from 'vue'
// import { Spin } from 'iview'
const addErrorLog = errorInfo => {
  const { statusText, status, request: { responseURL } } = errorInfo
  let info = {
    type: 'ajax',
    code: status,
    mes: statusText,
    url: responseURL
  }
  if (!responseURL.includes('save_error_logger')) store.dispatch('addErrorLog', info)
}

class HttpRequest {
  constructor (baseUrl = baseURL) {
    this.baseUrl = baseUrl
    this.queue = {}
  }
  getInsideConfig () {
    const config = {
      baseURL: this.baseUrl,
      headers: {
        //
      }
    }
    return config
  }
  destroy (url) {
    delete this.queue[url]
    if (!Object.keys(this.queue).length) {
      // Spin.hide()
    }
  }
  interceptors (instance, url) {
    // 请求拦截
    instance.interceptors.request.use(config => {
      // 添加全局的loading...
      if (!Object.keys(this.queue).length) {
        // Spin.show() // 不建议开启，因为界面不友好
      }
      if (window.abp.auth.getToken()) {
        config.headers.common['Authorization'] = 'Bearer ' + window.abp.auth.getToken()
      }
      config.headers.common['.AspNetCore.Culture'] = window.abp.utils.getCookieValue('Abp.Localization.CultureName')
      config.headers.common['Abp.TenantId'] = window.abp.multiTenancy.getTenantIdCookie()
      this.queue[url] = true
      return config
    }, error => {
      return Promise.reject(error)
    })
    // 响应拦截
    instance.interceptors.response.use(res => {
      this.destroy(url)
      // const { data, status } = res
      // return { data, status }
      return res.data
    }, error => {
      this.destroy(url)
      // let errorInfo = error.response
      // if (!errorInfo) {
      //   const { request: { statusText, status }, config } = JSON.parse(JSON.stringify(error))
      //   errorInfo = {
      //     statusText,
      //     status,
      //     request: { responseURL: config.url }
      //   }
      // }
      let vm = new Vue({})
      if (!!error.response && !!error.response.data.error && !!error.response.data.error.message && error.response.data.error.details) {
        // vm.$Modal.error({ title: error.response.data.error.message, content: error.response.data.error.details })
        vm.$Message.error({
          content: error.response.data.error.details,
          duration: 3,
          closable: true
        })
      } else if (!!error.response && !!error.response.data.error && !!error.response.data.error.message) {
        // vm.$Modal.error({ title: '错误', content: error.response.data.error.message })
        vm.$Message.error({
          content: error.response.data.error.message,
          duration: 3,
          closable: true
        })
      } else if (!error.response) {
        vm.$Message.error({
          content: window.abp.localization.localize('UnknownError'),
          duration: 3,
          closable: true
        })
      }

      // setTimeout(() => {
      //   vm.$Message.destroy()
      // }, 1000)
      // addErrorLog(errorInfo)
      return Promise.reject(error)
    })
  }
  request (options) {
    const instance = axios.create()
    options = Object.assign(this.getInsideConfig(), options)
    this.interceptors(instance, options.url)
    return instance(options)
  }
}
export default HttpRequest
