import axios from '@/libs/api.request'
export const getRoles = (keyword, skipCount, maxResultCount) => {
  return axios.request({
    url: 'api/services/app/Role/GetAll',
    params: {
      keyword,
      skipCount,
      maxResultCount
    },
    method: 'get'
  })
}

export const getRole = (id) => {
  return axios.request({
    url: 'api/services/app/Role/Get',
    params: {
      id
    },
    method: 'get'
  })
}

export const getRoleForEdit = (id) => {
  return axios.request({
    url: 'api/services/app/Role/GetRoleForEdit',
    params: {
      id
    },
    method: 'get'
  })
}

export const getPermissions = () => {
  return axios.request({
    url: 'api/services/app/Role/GetAllPermissions',
    method: 'get'
  })
}

export const createRole = (data) => {
  return axios.request({
    url: 'api/services/app/Role/Create',
    data: data,
    method: 'post'
  })
}
export const updateRole = (data) => {
  return axios.request({
    url: 'api/services/app/Role/Update',
    data: data,
    method: 'post'
  })
}

export const deleteRole = (id) => {
  return axios.request({
    url: 'api/services/app/Role/Delete',
    params: {
      id
    },
    method: 'delete'
  })
}
