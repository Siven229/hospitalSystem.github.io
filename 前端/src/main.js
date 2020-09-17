import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Vueaxios from 'vue-axios'
// import Message from 'element-ui'
// 先引入重置样式，后面文件可覆盖

// 全局配置
import '@/assets/scss/reset.scss'
import 'element-ui/lib/theme-chalk/index.css'
import Http from '@/api/config'
import './mock'

// 第三方包
import ElementUI from 'element-ui'

Vue.use(ElementUI)
//axios.get()
// 将http对象挂载到Vue原型上，实现所有Vue实例都可以通过$http调用这个HTTP对象
Vue.prototype.$http = Http
// Vue.prototype.$message = Message
// axios.interceptors.request.use(config => {
//   console.log(config)
//   config.headers.Authorization = window.sessionStorage.getItem('token')
//   //最后return config
//   return config
// })
//this.$axios.get()
Vue.config.productionTip = false
Vue.use(Vueaxios, Http)

// 添加路由守卫拦截，判断用户登录状态以跳转到对应页面
router.beforeEach((to, from, next) => {
  store.commit('getToken')
  let token = store.state.user.token
  if (!token && to.name !== 'login') {
    // next({ name: 'login' })
    next()
  } else {
    next()
  }
})

new Vue({
  router,
  store,
  render: h => h(App),
  created() {
    store.commit('addMenu', router)
  }
}).$mount('#app')
