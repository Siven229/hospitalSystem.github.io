import Cookie from 'js-cookie'
export default {
  state: {
    isCollapse: false,
    currentMenu: null,
    menu: [
      {
        path: '/',
        name: 'home',
        label: '首页',
        icon: 'home',
        url: 'Home/Home'
      },
      {
        path: '/medicine',
        name: 'medicine',
        label: '药品管理',
        icon: 'user',
        url: 'UserManage/UserManage'
      },
      {
        //path: '/user',
        // name: 'user',
        label: '财务管理',
        icon: 'location',
        index: 1,
        //url: 'UserManage/UserManage'
        children: [
          {
            path: '/salary',
            name: 'salary',
            label: '员工工资页',
            icon: 'setting',
            url: 'VideoManage/VideoManage.vue'
          },
          {
            path: '/bill',
            name: 'bill',
            label: '病人账单页',
            icon: 'setting',
            url: 'VideoManage/PatientBill.vue'
          }
        ]
      }
    ],
    tabsList: [
      {
        path: '/',
        name: 'home',
        label: '首页',
        icon: 'home'
      }
    ]
  },
  mutations: {
    // 设置菜单
    setMenu(state, val) {
      state.menu = val
      Cookie.set('menu', JSON.stringify(val))
      console.log(val, 'vuex')
    },
    // 登出菜单
    clearMenu(state) {
      // 清空菜单
      state.menu = []
      Cookie.remove('menu')
    },
    // 添加菜单
    addMenu(state, router) {
      if (!Cookie.get('menu')) {
        return
      }
      let menu = JSON.parse(Cookie.get('menu'))
      state.menu = menu
      let currentMenu = [
        {
          path: '/',
          component: () => import(`@/views/Main`),
          children: []
        }
      ]
      menu.forEach(item => {
        if (item.children) {
          item.children = item.children.map(item => {
            item.component = () => import(`@/views/${item.url}`)
            return item
          })
          // 添加动态路由
          currentMenu[0].children.push(...item.children)
        } else {
          item.component = () => import(`@/views/${item.url}`)
          currentMenu[0].children.push(item)
        }
      })
      console.log(currentMenu, 'cur')
      router.addRoutes(currentMenu)
    },
    selectMenu(state, val) {
      if (val.name !== 'home') {
        state.currentMenu = val
        let result = state.tabsList.findIndex(item => item.name === val.name)
        result === -1 ? state.tabsList.push(val) : ''
      } else {
        state.currentMenu = {}
      }
      // state.currentMenu = val.name !== 'home' ? val : null
    },
    closeTab(state, val) {
      let res = state.tabsList.findIndex(item => item.name === val.name)
      state.tabsList.splice(res, 1)
    },
    collapseMenu(state) {
      state.isCollapse = !state.isCollapse
    }
  },
  actions: {}
}
