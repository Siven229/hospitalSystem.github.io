import Mock from 'mockjs'
export default {
  getMenu: config => {
    const { username, password } = JSON.parse(config.body)
    console.log(JSON.parse(config.body))
    // 先 判断用户是否存在
    if (username === 'admin' || username === 'ahuntsun') {
      // 判断账号和密码是否对应
      if (username === 'admin' && password === '123456') {
        return {
          code: 20000,
          data: {
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
            //   {
            //     label: '财务管理页',
            //     icon: 'location',
            //     index: 2,
            //     children: [
            //       {
            //         path: '/page1',
            //         name: 'page1',
            //         label: '员工工资页',
            //         icon: 'setting',
            //         url: 'Other/PageOne'
            //       },
            //       {
            //         path: '/page2',
            //         name: 'page2',
            //         label: '医院流水页',
            //         icon: 'setting',
            //         url: 'Other/PageTwo'
            //       }
            //     ]
            //   }
            // 随机生成一个字符串当作token
            token: Mock.Random.guid(),
            message: '获取成功'
          }
        }
      } else if (username === 'ahuntsun' && password === '123456') {
        return {
          code: 20000,
          data: {
            menu: [
              {
                path: '/',
                name: 'home',
                label: '首页',
                icon: 's-home',
                url: 'Home/Home'
              },
              {
                path: '/video',
                name: 'video',
                label: '药品管理页',
                icon: 'video-play',
                url: 'VideoManage/VideoManage'
              }
            ],
            token: Mock.Random.guid(),
            message: '获取成功'
          }
        }
      } else {
        return {
          code: -999,
          data: {
            message: '密码错误'
          }
        }
      }
    } else {
      return {
        code: -999,
        data: {
          message: '用户不存在'
        }
      }
    }
  }
}
