import axios from '@/libs/api.request'
import Vue from 'vue'
export const AppSettingNames = {
  UiTheme: 'App.UiTheme',
  USD_CYN: 'App.USD_CYN',
  ChinalogisticsPrice: 'App.ChinalogisticsPrice'
}

export const updateSettingChinalogisticsPrice = (value) => {
  axios.request({
    url: 'api/services/app/Configuration/UpdateSettingChinalogisticsPrice',
    params: {
      value
    },
    method: 'put'
  }).then(res => {
    abp.setting.values[AppSettingNames.ChinalogisticsPrice] = value
    const vm = new Vue()
    vm.$Message.success({
      content: '保存成功',
      duration: 3,
      closable: true
    })
  })
}

export const getChinalogisticsPrice = () => {
  return abp.setting.get(AppSettingNames.ChinalogisticsPrice)
}

export const updateSettingUSD_CYN = (value) => {
  axios.request({
    url: 'api/services/app/Configuration/UpdateSettingUSD_CYN',
    params: {
      value
    },
    method: 'put'
  }).then(res => {
    abp.setting.values[AppSettingNames.USD_CYN] = value
    const vm = new Vue()
    vm.$Message.success({
      content: '保存成功',
      duration: 3,
      closable: true
    })
  })
}

export const getUSD_CYN = () => {
  return abp.setting.get(AppSettingNames.USD_CYN)
}
