import axios from 'axios'

// 创建一个 axios 实例
const service = axios.create({
  // 请求超时时间,3秒
  timeout: 30000
})

// 添加请求拦截器，带token的，use里接受一个回调函数作为参数
service.interceptors.request.use(
  //成功的回调，成功想做的写在里面
  config => {
    return config
  },
  //失败的回调
  err => {
    console.log(err)
  }
)

// 添加响应拦截器
service.interceptors.response.use(
  //第一个参数response获得响应的一些数据，就写在这里面
  response => {
    let res = {}
    //响应的状态码返回，响应的拦截器，看成功时想怎么做啥的
    //if（200）表示成功if(404)可让其跳转到404页面,这里可加
    res.status = response.status
    res.data = response.data
    return res
  },
  err => console.log(err) //失败的回调
)
//将service输出
export default service
