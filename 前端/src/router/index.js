import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

// const routes = [
//   {
//     path: '/login',
//     name: 'login',
//     component: () => import('@/views/Login/login')
//   }
// ]
const routes = [
  // {
  //   path: '/login',
  //   name: 'login',
  //   component: () => import('@/views/Login/login')
  // }
  {
    path: '/',
    name: 'home',
    component: () => import('@/views/Main.vue')
  }
  // {
  //   path: '/user',
  //   name: 'user',
  //   component: () => import('@/views/UserManage/UserManage.vue')
  // }
]

const router = new VueRouter({
  routes
})

export default router
