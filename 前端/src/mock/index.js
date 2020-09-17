import Mock from 'mockjs'
//引入API在。vue里调用时才知道拦截什么请求
//import homeApi from './home.js'
import userApi from './user'
import permissionApi from './permission'
import salaryApi from './salary'
import billApi from './bill'

// 设置延时200~2000ms
Mock.setup({
  timeout: '200-1000'
})

// 首页相关
// 拦截/home/getData，这是ajax请求的路劲
//第一个参数就是rul,拦截对应ajax请求
//用/作为正则，判断中间的数据，由于正则里/是特殊符号，所以要用、转意一下
//返回的是homeApi.getStatisticalData返回的结果作为响应数据，返回到我们拦截的ajax
//Mock.mock(/\/home\/getData/, 'get', homeApi.getStatisticalData)

// 用户相关
Mock.mock(/\/user\/getUser/, 'get', userApi.getUserList)
Mock.mock(/\/user\/del/, 'get', userApi.deleteUser)
Mock.mock(/\/user\/batchremove/, 'get', userApi.batchremove)
Mock.mock(/\/user\/add/, 'post', userApi.createUser)
Mock.mock(/\/user\/edit/, 'post', userApi.updateUser)
//Mock.mock(/\/home\/getData/, 'get', homeApi.getStatisticalData)
Mock.mock(/\/home\/search/, 'get', userApi.searchList)
//Mock.mock(/\/home\/search/, 'get', userApi.searchListID)

//薪水相关
Mock.mock(/\/user\/sgetUser/, 'get', salaryApi.getUserList)
Mock.mock(/\/user\/sdel/, 'get', salaryApi.deleteUser)
Mock.mock(/\/user\/sbatchremove/, 'get', salaryApi.batchremove)
Mock.mock(/\/user\/sadd/, 'post', salaryApi.createUser)
Mock.mock(/\/user\/sedit/, 'post', salaryApi.updateUser)
//Mock.mock(/\/home\/getData/, 'get', homeApi.getStatisticalData)
Mock.mock(/\/home\/ssearch/, 'get', salaryApi.searchList)

//病人账单相关
Mock.mock(/\/user\/bgetUser/, 'get', billApi.getUserList)
Mock.mock(/\/user\/bdel/, 'get', billApi.deleteUser)
Mock.mock(/\/user\/bbatchremove/, 'get', billApi.batchremove)
Mock.mock(/\/user\/badd/, 'post', billApi.createUser)
Mock.mock(/\/user\/bedit/, 'post', billApi.updateUser)
//Mock.mock(/\/home\/getData/, 'get', homeApi.getStatisticalData)
Mock.mock(/\/home\/bsearch/, 'get', billApi.searchList)
// 权限相关
Mock.mock(/\/permission\/getMenu/, 'post', permissionApi.getMenu)
