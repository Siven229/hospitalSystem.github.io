<template>
  <div class="manage">
    <el-dialog
      :title="operateType === 'add' ? '新增用户' : '更新用户'"
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
    <div class="manage-header">
      <el-button type="primary" @click="addUser">+ 新增</el-button>
      <common-form inline :formLabel="formLabel" :form="searchForm">
        <el-button type="primary" @click="searchUser">搜索</el-button>
      </common-form>
    </div>
    <common-table
      :tableData="tableData"
      :tableLabel="tableLabel"
      :optable="operateFormLabel"
      :config="config"
      @changePage="getList"
      @refu="refundmoney"
      @edit="editUser"
      @del="delUser"
    ></common-table>
  </div>
</template>

<script>
import CommonForm from '../../components/CommonForm'
import CommonTable from '../../components/forBillPatient'
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
          prop: 'bill_ID',
          label: '账单编号'
        },
        {
          prop: 'bill_patient',
          label: '病人编号'
        },
        {
          prop: 'transaction_ti',
          label: '交易时间'
          //width: 320
        },
        {
          prop: 'type',
          label: '类型'
        },
        {
          prop: 'cost',
          label: '费用'
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
      operateForm: {
        bill_ID: '',
        bill_patient: '',
        transaction: '',
        type: '',
        cost: 1.0
      },
      operateFormLabel: [
        {
          model: 'bill_ID',
          label: '账单编号'
        },
        {
          model: 'bill_patient',
          label: '病人编号'
        },
        {
          model: 'transaction',
          label: '交易时间'
          //width: 320
        },
        {
          model: 'type',
          label: '类型'
          //width: 320
        },
        {
          model: 'cost',
          label: '费用'
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
      this.config.loading = true
      this.$http
        .get('https://localhost:44347/Bill/Display', {
          params: {
            page: this.config.page
          }
        })
        .then(res => {
          //对性别数据二次处理
          console.log(res.data)
          this.tableData = res.data //list.map(item => {
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
    confirm() {
      if (this.operateType === 'edit') {
        //post将数据传递过去，用then输出这个结果then(res => {console.log(res.data)
        this.$http.post('./api/user/bedit', this.operateForm).then(res => {
          console.log(res.data)
          this.isShow = false
          //重新获取数据，达到刷新效果
          this.getList()
        })
      } else if (this.operateType === 'add') {
        this.$http.post('/api/user/badd', this.operateForm).then(res => {
          //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
          console.log(res.data)
          this.isShow = false
          // 重新获取数据，达到刷新效果
          this.getList()
        })
      }
    },
    delUser(row) {
      this.$confirm('此操作将永久删除该用户, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        let mid = {
          bill_ID: row.bill_ID
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
          .catch(() => {
            this.$message({
              type: 'info',
              message: '已取消删除'
            })
          })
      })
      // let mid = {
      //   ID: row.med_ID
      // }
      // //let id = row.med_ID
      // this.$http
      //     .post('https://localhost:44347/Medicine/Delete ', mid)
      //       .then(res => {
      //         console.log(res.data)
      //         this.$message({
      //           type: 'success',
      //           message: '删除成功!'
      //         })
      //       })
      // .then(() => {
      //   let id = row.id
      //   let parID = row.bill_ID
      //   axios
      //     .post('url', parID)
      //     .then(res => {
      //       console.log(res)
      //       this.$message({
      //         type: 'success',
      //         message: '删除成功!'
      //       })
      //     })
      //     .catch(res => {
      //       console.log(res)
      //       this.$message({
      //         type: 'info',
      //         message: '已取消删除'
      //       })
      //     })
      //   this.$http
      //     .get('/api/user/del', {
      //       params: {
      //         id
      //       }
      //     })
      //     .then(res => {
      //       console.log(res.data)
      //       this.$message({
      //         type: 'success',
      //         message: '删除成功!'
      //       })
      //     })
      // })
      // .catch(() => {
      //   this.$message({
      //     type: 'info',
      //     message: '已取消删除'
      //   })
      // })
    },
    addUser() {
      this.operateForm = {
        bill_ID: this.bill_ID,
        bill_patient: this.bill_patient,
        transaction: this.transaction,
        type: this.type,
        cost: this.cost
      }
      this.operateType = 'add'
      this.isShow = true
    },
    searchUser() {
      this.config.loading = true
      // eslint-disable-next-line no-unused-vars
      let mid = {
        bill_patient: this.searchForm.keyword
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
        .post('https://localhost:44347/Bill/Query', mid)
        .then(res => {
          console.log('成功')
          console.log(res)
          //this.config.total = res.data.count
          //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
          //console.log(res.data)
          // 重新获取数据，达到刷新效果
          this.tableData = res.data
          this.config.total = res.data.count
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
    },
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
    // getmon(row){

    // },
    refundmoney(row) {
      let mid = {
        bill_ID: row.bill_ID
      }
      let parlist5 = {
        bill_ID: row.bill_ID,
        bill_patient: row.bill_patient,
        transaction: row.transaction,
        type: 'row.type',
        cost: row.cost
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
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
      this.$http.post('/api/user/badd', parlist5).then(res => {
        //在此处进行同名药物的判断，先遍历药品的编号数组，若有同名的，则该同名药物的数量增加，然后geylist,若没有同名，则增加一行
        console.log(res.data)
        this.isShow = false
        // 重新获取数据，达到刷新效果
        this.getList()
      })
    }
  },
  created() {
    this.getList()
  }
}
</script>

<style lang="scss" scoped>
@import '@/assets/scss/common';
</style>
