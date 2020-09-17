<template>
  <div class="manage">
    <el-dialog
      :title="operateType === 'add' ? '新增用户' : '更新用户'"
      v-if="operateType !== 'diagnose'"
      :visible.sync="isShow"
    >
      <common-form
        :formLabel="operateFormLabel"
        :form="operateForm"
      ></common-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="isShow = false">取 消</el-button>
        <el-button type="primary" @click="confirm">确 定</el-button>
      </div>
    </el-dialog>
    <el-dialog
      title="诊断开药"
      v-if="operateType === 'diagnose'"
      :visible.sync="isShow"
    >
      <common-form :formLabel="diagFormLabel" :form="diagForm"></common-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="isShow = false">取 消</el-button>
        <el-button type="primary" @click="confirm">确 定</el-button>
      </div>
    </el-dialog>
    <div class="manage-header">
      <el-button type="primary" @click="addUser">+ 新增</el-button>
      <el-button type="primary" @click="diagnosed">诊断开药</el-button>
      <common-form
        inline
        :formLabel="formLabel"
        :form="searchForm"
        style="margin-left:800px"
      >
        <!-- style="margin-left:1200px" -->
        <el-button type="primary" @click="searchUser">搜索</el-button>
      </common-form>
    </div>
    <common-table
      :tableData="tableData"
      :tableLabel="tableLabel"
      :config="config"
      @changePage="getList"
      @edit="editUser"
      @del="delUser"
    ></common-table>
  </div>
</template>

<script>
import CommonForm from '../../components/CommonForm'
import CommonTable from '../../components/CommonTable'
import axios from '@/api/config'
export default {
  components: {
    CommonForm,
    CommonTable
  },
  data() {
    return {
      operateType: 'add',
      isShow: false,
      tableData: [],
      // tableLabel: [
      //   {
      //     prop: 'name',
      //     label: '药品名称'
      //   },
      //   {
      //     prop: 'age',
      //     label: '药品数量'
      //   },
      //   {
      //     prop: 'sexLabel',
      //     label: '出产地'
      //   },
      //   {
      //     prop: 'birth',
      //     label: '生产日期',
      //     width: 200
      //   },
      //   {
      //     prop: 'addr',
      //     label: '生产商',
      //     width: 320
      //   }
      // ],
      tableLabel: [
        {
          prop: 'med_ID',
          label: '药品编号'
        },
        {
          prop: 'med_name',
          label: '药品名称'
        },
        {
          prop: 'cost_price',
          label: '药品进价'
          //width: 320
        },
        {
          prop: 'sell_price',
          label: '药品售价'
          //width: 320
        },
        {
          prop: 'unit',
          label: '计量单位'
          //width: 320
        },
        {
          prop: 'num',
          label: '药品数量'
        },
        {
          prop: 'producer',
          label: '生产商'
          //width: 200
        }
      ],
      config: {
        // 当前页
        page: 1,
        // 总页数
        total: 10,
        loading: false
      },
      diagForm: {
        doc_ID: '',
        dia_patient: '',
        visit_ID: '',
        med_ID: '',
        med_Num: 1,
        result: ''
      },
      operateForm: {
        med_ID: '',
        med_name: '',
        cost_price: 1,
        sell_price: 1,
        unit: '',
        num: 1,
        producer: ''
      },
      operateFormLabel: [
        {
          model: 'med_ID',
          label: '药品编号'
        },
        {
          model: 'med_name',
          label: '药品名称'
        },
        {
          model: 'cost_price',
          label: '药品进价'
          //width: 320
        },
        {
          model: 'sell_price',
          label: '药品售价'
          //width: 320
        },
        {
          model: 'unit',
          label: '计量单位'
          //width: 320
        },
        {
          model: 'num',
          label: '药品数量'
        },
        {
          model: 'producer',
          label: '生产商'
          // type: 'date'
          //width: 200
        }
      ],
      diagFormLabel: [
        {
          model: 'doc_ID',
          label: '医生编号'
        },
        {
          model: 'dia_patient',
          label: '病人编号'
        },
        {
          model: 'visit_ID',
          label: '问诊号'
        },
        {
          model: 'med_ID',
          label: '药品编号'
          //width: 200
        },
        {
          model: 'med_Num',
          label: '药品数量'
          //width: 320
        },
        {
          model: 'result',
          label: '医嘱'
          //width: 320
        }
      ],
      searchForm: {
        keyword: ''
      },
      formLabel: [
        {
          model: 'keyword',
          label: ''
        }
      ]
    }
  },
  methods: {
    //获取表格数据
    // async getList() {
    //   this.config.loading = true
    //   const { data: res } = await this.$axios
    //     //此处获取后端数据
    //     .get('~/Medicine/GetAll')
    //     .then(res => {
    //       //对后端数据进行处理
    //       if (!res) {
    //         return this.$message.error('获取药品列表失败')
    //       }
    //       this.config.total = res.data.count
    //       this.config.loading = false
    //     })
    // },
    getList() {
      // 先设置加载状态
      /*this.config.loading = true
      this.$http
        .get('/api/user/getUser', {
          params: {
            page: this.config.page
          }
        })
        .then(res => {
          //对性别数据二次处理
          this.tableData = res.data.list //.map(item => {
          // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
          //return 形成一个数组返回，item是一个数组
          //return item
          //})
          this.config.total = res.data.count
          this.config.loading = false
        })*/
      this.config.loading = true
      this.$http
        .get('https://localhost:44347/Medicine/Display', {
          params: {
            page: this.config.page
          }
        })
        .then(res => {
          //对性别数据二次处理
          this.tableData = res.data //.map(item => {
          // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
          //return 形成一个数组返回，item是一个数组
          //return item
          //})
          this.config.total = res.data.count
          this.config.loading = false
        })
    },
    editUser(row) {
      this.operateType = 'edit'
      this.isShow = true
      this.operateForm = row
    },
    diagnosed() {
      this.operateType = 'diagnose'
      this.isShow = true
      this.diagForm = {
        doc_ID: this.doc_ID,
        dia_patient: this.dia_patient,
        visit_ID: this.visit_ID,
        med_ID: this.med_ID,
        med_Num: this.med_Num,
        result: this.result
      }
    },
    confirm() {
      if (this.operateType === 'edit') {
        //post将数据传递过去，用then输出这个结果then(res => {console.log(res.data)
        this.$http.post('./api/user/edit', this.operateForm).then(res => {
          console.log(res.data)
          this.isShow = false
          //重新获取数据，达到刷新效果
          this.getList()
        })
      } else if (this.operateType === 'add') {
        this.$http.post('/api/user/add', this.operateForm).then(res => {
          //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
          console.log(res.data)
          this.isShow = false
          // 重新获取数据，达到刷新效果
          this.getList()
        })
      } else if (this.operateType === 'diagnose') {
        let pari3 = this.diagForm
        axios.post('https://localhost:44347/Diagnosis/Add', pari3).then(res => {
          //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
          console.log(res.data)
          this.isShow = false
          // 重新获取数据，达到刷新效果
        })
      }
    },
    delUser(row) {
      this.$confirm('此操作将永久删除该用户, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          let mid = {
            ID: row.med_ID
          }
          //let id = row.med_ID
          this.$http
            .post('https://localhost:44347/Medicine/Delete ', mid)
            .then(res => {
              console.log(res.data)
              this.$message({
                type: 'success',
                message: '删除成功!'
              })
            })
        })
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
    },
    addUser() {
      this.operateForm = {
        med_ID: this.med_ID,
        med_name: this.med_name,
        cost_price: this.cost_price,
        sell_price: this.sell_price,
        unit: this.unit,
        num: this.num,
        producer: this.producer
      }
      this.operateType = 'add'
      this.isShow = true
    },
    searchUser() {
      this.config.loading = true
      // eslint-disable-next-line no-unused-vars
      let mid = {
        ID: this.searchForm.keyword
      }
      console.log(mid)
      //let bid = '001'
      // {
      //     params: {
      //       //med_name: this.searchForm.keyword
      //       med_ID: this.searchForm.keyword
      //     }
      //   }
      axios
        .post('https://localhost:44347/Medicine/Query', mid)
        .then(res => {
          console.log('成功')
          console.log(res)
          //this.config.total = res.data.count
          //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
          //console.log(res.data)
          // 重新获取数据，达到刷新效果
          this.tableData = res.data
          this.config.total = 1
          this.config.loading = false
        })
        .catch(res => {
          console.log('失败')
          console.log(res.data)
        })
      // .catch(function() {
      //   this.$http
      //     .get('/api/home/searchID', {
      //       params: {
      //         ID: this.searchForm.keyword
      //       }
      //     })
      //     .then(res => {
      //       //this.config.total = res.data.count
      //       //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
      //       //console.log(res.data)
      //       // 重新获取数据，达到刷新效果
      //       this.tableData = res.data.list
      //       this.config.total = res.data.count
      //       this.config.loading = false
      //     })
      // })
    }
    // searchUser() {
    //   this.config.loading = true
    //   this.$http
    //     .get('/api/user/getUser', {
    //       params: {
    //         med_name: this.searchForm.keyword
    //       }
    //     })
    //     .then(res => {
    //       // 处理性别问题
    //       this.tableData = res.data.list.map(item => {
    //         item.sexLabel = item.sex === 0 ? '女' : '男'
    //         return item
    //       })
    //       this.config.total = res.data.count
    //       this.config.loading = false
    //     })
    // }
  },
  created() {
    // let form1 = {
    //   username: 'admin',
    //   password: '123456'
    // }
    // this.$http.post('api/permission/getMenu', form1).then(res => {
    //   res = res.data
    //   if (res.code === 20000) {
    //     // 先清除侧边栏菜单，以免用户二次登录
    //     this.$store.commit('clearMenu')
    //     // 设置侧边栏菜单
    //     this.$store.commit('setMenu', res.data.menu)
    //     this.$store.commit('setToken', res.data.token)
    //     this.$store.commit('addMenu', this.$router)
    //     //this.$router.push({ name: 'home' })
    //   } else {
    //     this.$message.warning(res.data.message)
    //   }
    // })
    this.getList()
  }
}
</script>

<style lang="scss" scoped>
//@import '@/assets/scss/common';
.manage {
  height: 90%;
  padding-bottom: 20px;
  overflow: hidden;
  &-header {
    display: flex;
    // justify-content: space-between;
    align-items: flex-start;
  }
}
</style>
