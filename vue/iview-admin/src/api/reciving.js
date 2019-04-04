import axios from '@/libs/api.request'

export const getReceiving = (id) => {
  return axios.request({
    url: 'api/services/app/Receiving/GetReceiving',
    params: {
      id
    },
    method: 'get'
  })
}

export const getReceivings = () => {
  return axios.request({
    url: 'api/services/app/Receiving/GetReceivings',
    method: 'get'
  })
}
export const createOrUpdate = ({ id, address }) => {
  return axios.request({
    url: 'api/services/app/Receiving/CreateOrUpdate',
    data: {
      id, address
    },
    method: 'post'
  })
}

export const deleteRevicing = (id) => {
  return axios.request({
    url: 'api/services/app/Receiving/Delete',
    params: {
      id
    },
    method: 'delete'
  })
}

export const getPersion = (id) => {
  return axios.request({
    url: 'api/services/app/Receiving/GetPersion',
    params: {
      id
    },
    method: 'get'
  })
}

export const getPersions = (receivingId) => {
  return axios.request({
    url: 'api/services/app/Receiving/GetPersions',
    method: 'get',
    params: {
      receivingId
    }
  })
}
export const createOrUpdatePersion = ({ id, name, receivingId }) => {
  return axios.request({
    url: 'api/services/app/Receiving/createOrUpdatePersion',
    data: {
      id, name, receivingId
    },
    method: 'post'
  })
}

export const deletePersion = (id) => {
  return axios.request({
    url: 'api/services/app/Receiving/DeletePersion',
    params: {
      id
    },
    method: 'delete'
  })
}
