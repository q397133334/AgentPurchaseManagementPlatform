import axios from '@/libs/api.request'

// export const login = ({ userName, password }) => {
//   const data = {
//     userName,
//     password
//   }
//   return axios.request({
//     url: 'login',
//     data,
//     method: 'post'
//   })
// }
export const login = ({ userNameOrEmailAddress, password, rememberClient }) => {
  const data = {
    userNameOrEmailAddress,
    password,
    rememberClient
  }
  return axios.request({
    url: 'api/TokenAuth/Authenticate',
    data,
    method: 'post'
  })
}

export const getUserAll = (keyword, isActive, skipCount, maxResultCount) => {
  return axios.request({
    url: 'api/services/app/User/GetAll',
    data: {
      keyword, isActive, skipCount, maxResultCount
    },
    method: 'get'
  })
}

export const create = (user) => {
  return axios.request({
    url: 'api/services/app/User/Create',
    data: user,
    method: 'post'
  })
}

export const deleteUser = (id) => {
  return axios.request({
    url: 'api/services/app/User/Delete?id=' + id,
    method: 'delete'
  })
}

export const getUserRoles = () => {
  return axios.request({
    url: 'api/services/app/User/GetRoles',
    method: 'get'
  })
}
export const getUser = (id) => {
  return axios.request({
    url: 'api/services/app/User/Get',
    params: {
      id
    },
    method: 'get'
  })
}

export const getUserInfo = (token) => {
  return axios.request({
    url: 'get_info',
    params: {
      token
    },
    method: 'get'
  })
}

export const logout = (token) => {
  return axios.request({
    url: 'logout',
    method: 'post'
  })
}

export const getUnreadCount = () => {
  return axios.request({
    url: 'message/count',
    method: 'get'
  })
}

export const getMessage = () => {
  return axios.request({
    url: 'message/init',
    method: 'get'
  })
}

export const getContentByMsgId = msg_id => {
  return axios.request({
    url: 'message/content',
    method: 'get',
    params: {
      msg_id
    }
  })
}

export const hasRead = msg_id => {
  return axios.request({
    url: 'message/has_read',
    method: 'post',
    data: {
      msg_id
    }
  })
}

export const removeReaded = msg_id => {
  return axios.request({
    url: 'message/remove_readed',
    method: 'post',
    data: {
      msg_id
    }
  })
}

export const restoreTrash = msg_id => {
  return axios.request({
    url: 'message/restore',
    method: 'post',
    data: {
      msg_id
    }
  })
}
