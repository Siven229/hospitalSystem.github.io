import Mock from 'mockjs'
import axios from '@/api/config'

//  get请求从config.url获取参数，post从config.body中获取参数
function param2Obj(url) {
  const search = url.split('?')[1]
  if (!search) {
    return {}
  }
  return JSON.parse(
    '{"' +
      decodeURIComponent(search)
        .replace(/"/g, '\\"')
        .replace(/&/g, '","')
        .replace(/=/g, '":"') +
      '"}'
  )
}

let List = []
const count = 200

for (let i = 0; i < count; i++) {
  List.push(
    //随机生成这样一个模板的数据
    Mock.mock({
      // id: Mock.Random.guid(),
      // name: Mock.Random.cname(),
      // addr: Mock.mock('@county(true)'),
      // 'age|18-60': 1,
      // birth: Mock.Random.date(),
      // sex: Mock.Random.integer(0, 1)
      id: Mock.Random.guid(),
      bill_ID: Mock.Random.integer(10000, 99999),
      bill_patient: Mock.Random.cname(),
      transaction_ti: Mock.Random.cname(),
      type: Mock.Random.cword('收退'),
      cost: Mock.Random.integer(10000, 99999)
    })
  )
}
//List = axios.get('~/Medicine/GetAll').then(res => console(res))
// for (let i = 0; i < count; i++) {
//   List.push(
//     //随机生成这样一个模板的数据
//     axios.get('~/Medicine/GetAll').then(res => console(res))
//   )
// }

export default {
  // searchList: config => {
  //   const { med_name } = param2Obj(config.url)
  //   let par = List.count
  //   for (let i = 0; i < par; i++) {
  //     if (med_name === List[i].med_name) {
  //       return List[i]
  //     } else return false
  //   }
  // },
  // searchListID: config => {
  //   const { ID } = param2Obj(config.url)
  //   //let par = List.count
  //   const parlist = List.filter(user => {
  //     if (ID && user.med_ID !== ID) return false
  //     return true
  //   })
  //   // for (let i = 0; i < par; i++) {
  //   //   if (name === List[i].name) {
  //   //     parlist.push(List[i])
  //   //   }
  //   // }
  //   // if (!parlist.length) {
  //   //   return false
  //   // }
  //   return {
  //     code: 2101,
  //     count: parlist.length,
  //     list: parlist
  //   }
  // },
  searchList: config => {
    const { bill_patient } = param2Obj(config.url)
    //let par = List.count
    const parlist = List.filter(user => {
      if (bill_patient && user.bill_patient.indexOf(bill_patient) === -1)
        return false
      return true
    })
    // for (let i = 0; i < par; i++) {
    //   if (name === List[i].name) {
    //     parlist.push(List[i])
    //   }
    // }
    // if (!parlist.length) {
    //   return false
    // }
    return {
      code: 2101,
      count: parlist.length,
      list: parlist
    }
  },
  /**
   * 获取列表
   * 要带参数 name, page, limt; name可以不填, page,limit有默认值。
   * @param name, page, limit
   * @return {{code: number, count: number, data: *[]}}
   */
  getUserList: config => {
    const { bill_patient, page = 1, limit = 20 } = param2Obj(config.url)
    console.log(
      'bill_patient:' + bill_patient,
      'page:' + page,
      '分页大小limit:' + limit
    )
    List = []
    axios
      .get('https://localhost:44347/Medicine/Display', {
        params: {
          page: this.config.page
        }
      })
      .then(res => {
        List = res.data
        //对性别数据二次处理
        //.map(item => {
        // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
        //return 形成一个数组返回，item是一个数组
        //return item
        //})
      })
    const mockList = List.filter(user => {
      if (
        bill_patient &&
        user.bill_patient.indexOf(bill_patient) === -1 &&
        user.addr.indexOf(bill_patient) === -1
      )
        return false
      return true
    })
    const pageList = mockList.filter(
      (item, index) => index < limit * page && index >= limit * (page - 1)
    )
    return {
      code: 20000,
      count: mockList.length,
      list: pageList
    }
  },
  /**
   * 增加用户
   * @param med_ID,med_name,num,birth,unit,cost_price,sell_price,
   * @return {{code: number, data: {message: string}}}
   */
  createUser: config => {
    const { bill_ID, bill_patient, transaction_ti, type, cost } = JSON.parse(
      config.body
    )
    console.log(JSON.parse(config.body))
    //unshift向数组开头插入一个数据
    List.unshift({
      id: Mock.Random.guid(),
      bill_ID: bill_ID,
      name: name,
      bill_patient: bill_patient,
      transaction_ti: transaction_ti,
      type: type,
      cost: cost
    })
    // axios.post('~/Medicine/putAll', {
    //   id: Mock.Random.guid(),
    //   bill_ID: bill_ID,
    //   name: name,
    //   bill_patient: bill_patient,
    //   transaction_ti: transaction_ti,
    //   type: type,
    //   cost: cost
    // })
    let pari = {
      bill_ID: bill_ID,
      name: name,
      bill_patient: bill_patient,
      type: type,
      cost: cost
    }
    axios
      .post(
        'https://localhost:44347/Bill/Create',
        // id: Mock.Random.guid(),
        pari
      )
      .then(res => {
        console.log('成功')
        console.log(res.data)
        return true
        // eslint-disable-next-line no-unreachable
        this.$router.push('/home')
      })
      .catch(res => {
        console.log('失败')
        console.log(res.data)
        return false
      })
    //this.getList()
    // .then(res => {
    //   // // eslint-disable-next-line no-unused-vars
    //   // let i
    //   // i = res
    //   return this.$message.error('登陆成功')
    // })
    // return {
    //   code: 20000,
    //   data: {
    //     message: '添加成功'
    //   }
    // }
  },
  /**
   * 删除用户
   * @param id
   * @return {*}
   */
  deleteUser: config => {
    const { id } = param2Obj(config.url)
    if (!id) {
      return {
        code: -999,
        message: '参数不正确'
      }
    } else {
      List = List.filter(u => u.id !== id)
      return {
        code: 20000,
        message: '删除成功'
      }
    }
  },
  /**
   * 批量删除
   * @param config
   * @return {{code: number, data: {message: string}}}
   */
  batchremove: config => {
    let { ids } = param2Obj(config.url)
    ids = ids.split(',')
    List = List.filter(u => !ids.includes(u.id))
    return {
      code: 20000,
      data: {
        message: '批量删除成功'
      }
    }
  },
  /**
   * 修改用户
   * @param id, med_ID,med_name,num,birth,unit,cost_price,sell_price,
   * @return {{code: number, data: {message: string}}}
   */
  updateUser: config => {
    const {
      id,
      bill_ID,
      bill_patient,
      transaction_ti,
      type,
      cost
    } = JSON.parse(config.body)
    //const unit_num = parseInt(unit)
    let parlist = {
      bill_ID,
      bill_patient,
      transaction_ti,
      type,
      cost
    }
    axios
      .post('https://localhost:44347/Medicine/Edit', parlist)
      .then(res => {
        console.log(res)
        console.log('成功')
      })
      .catch(res => {
        console.log(res)
        console.log('失败')
      })
    List.some(u => {
      if (u.id === id) {
        u.bill_ID = bill_ID
        u.bill_patient = bill_patient
        u.type = type
        u.cost = cost
        return true
      }
    })
    return {
      code: 20000,
      data: {
        message: '编辑成功'
      }
    }
  }
}
