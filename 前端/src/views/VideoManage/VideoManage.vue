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
      <div
        class="money"
        v-for="item in countmoney"
        :key="item.model"
        :label="item.label"
      >
        <el-input
          v-model="input1"
          :placeholder="`${item.alexpend}`"
          style="width: 200px"
          :disabled="true"
          v-if="item.model"
        >
          >
          <template slot="prepend">已支付：</template></el-input
        ><el-input
          style="width: 200px;height: 90%;
  padding-bottom: 20px"
          :placeholder="`${item.waitexpend}`"
          v-model="input1"
          :disabled="true"
          v-if="item.model"
        >
          <template slot="prepend" style="background: green;color: green"
            >待支付：</template
          >
        </el-input>
      </div>
      <common-form inline :formLabel="formLabel" :form="searchForm">
        <el-button type="primary" @click="searchUser">搜索</el-button>
      </common-form>
    </div>
    <el-tabs type="border-card" width="50px">
      <el-tab-pane label="医生工资" @click="doctorsalary"></el-tab-pane>
      <el-tab-pane label="护士工资" @click="nursesalary"></el-tab-pane>
    </el-tabs>
    <common-table
      :tableData="tableData"
      :tableLabel="tableLabel"
      :config="config"
      @changePage="getList"
      @zhifu="givemoney"
    ></common-table>
  </div>
</template>

<script>
import CommonForm from '../../components/CommonForm'
import CommonTable from '../../components/financialmanage'
import axios from '@/api/config'
export default {
  components: {
    CommonForm,
    CommonTable
  },
  data() {
    return {
      operateType: 'add',
      totalsalary: 1,
      isShow: false,
      tableData: [],
      tabletype: 1,
      countmoney: [
        {
          model: 'expend',
          alexpend: 0,
          waitexpend: this.totalsalary
        }
      ],
      tableLabel: [
        {
          prop: 'doctor_ID',
          label: '员工编号'
        },
        {
          prop: 'doctor_name',
          label: '员工姓名'
        },
        {
          prop: 'doctor_dept',
          label: '科室'
        },
        {
          prop: 'doctor_position',
          label: '职位'
          //width: 200
        },
        {
          prop: 'salary',
          label: '月薪'
          //width: 200
        },
        {
          prop: 'age',
          label: '年龄'
        },
        {
          prop: 'sex',
          label: '性别'
        }
      ],
      // tableLabel: [
      //   {
      //     prop: 'med_ID',
      //     label: '药品编号'
      //   },
      //   {
      //     prop: 'med_name',
      //     label: '药品名称'
      //   },
      //   {
      //     prop: 'cost_price',
      //     label: '药品进价'
      //     //width: 320
      //   },
      //   {
      //     prop: 'sell_price',
      //     label: '药品售价'
      //     //width: 320
      //   },
      //   {
      //     prop: 'unit',
      //     label: '计量单位'
      //     //width: 320
      //   },
      //   {
      //     prop: 'num',
      //     label: '药品数量'
      //   },
      //   {
      //     prop: 'producer',
      //     label: '生产商'
      //     //width: 200
      //   }
      // ],
      config: {
        // 当前页
        page: 1,
        // 总页数
        total: 20,
        loading: false
      },
      operateForm: {
        doctor_ID: '',
        doctor_name: '',
        doctor_dept: '',
        doctor_position: '',
        salary: 1.0,
        age: 1,
        sex: ''
      },
      operateFormLabel: [
        {
          model: 'doctor_ID',
          label: '员工编号'
        },
        {
          model: 'doctor_name',
          label: '员工姓名'
        },
        {
          model: 'doctor_dept',
          label: '科室'
          //width: 320
        },
        {
          model: 'doctor_position',
          label: '职位'
          //width: 320
        },
        {
          model: 'salary',
          label: '月薪'
          //width: 320
        },
        {
          model: 'age',
          label: '年龄'
          //width: 320
        },
        {
          model: 'sex',
          label: '性别'
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
    monn() {
      return '大数据开动脑筋扩大'
    },
    // givemoney() {

    // },
    doctorsalary() {
      this.tabletype = 1
      this.operateFormLabel = [
        {
          model: 'doctor_ID',
          label: '员工编号'
        },
        {
          model: 'doctor_name',
          label: '员工姓名'
        },
        {
          model: 'doctor_dept',
          label: '科室'
          //width: 320
        },
        {
          model: 'doctor_position',
          label: '职位'
          //width: 320
        },
        {
          model: 'salary',
          label: '月薪'
          //width: 320
        },
        {
          model: 'age',
          label: '年龄'
          //width: 320
        },
        {
          model: 'sex',
          label: '性别'
          //width: 320
        }
      ]
      this.operateForm = {
        doctor_ID: '',
        doctor_name: '',
        doctor_dept: '',
        doctor_position: '',
        salary: 1.0,
        age: 1,
        sex: ''
      }
      this.tableLabel = [
        {
          prop: 'doctor_ID',
          label: '员工编号'
        },
        {
          prop: 'doctor_name',
          label: '员工姓名'
        },
        {
          prop: 'doctor_dept',
          label: '科室'
        },
        {
          prop: 'doctor_position',
          label: '职位'
          //width: 200
        },
        {
          prop: 'salary',
          label: '月薪'
          //width: 200
        },
        {
          prop: 'age',
          label: '年龄'
        },
        {
          prop: 'sex',
          label: '性别'
        }
      ]
      this.getList()
      return true
    },
    nursesalary() {
      this.tabletype = 0
      this.operateFormLabel = [
        {
          model: 'nurse_ID',
          label: '员工编号'
        },
        {
          model: 'nurse_name',
          label: '员工姓名'
        },
        {
          model: 'nurse_dept',
          label: '科室'
          //width: 320
        },
        {
          model: 'nurse_position',
          label: '职位'
          //width: 320
        },
        {
          model: 'salary',
          label: '月薪'
          //width: 320
        },
        {
          model: 'age',
          label: '年龄'
          //width: 320
        },
        {
          model: 'sex',
          label: '性别'
          //width: 320
        }
      ]
      this.operateForm = {
        nurse_ID: '',
        nurse_name: '',
        nurse_dept: '',
        nurse_position: '',
        salary: 1.0,
        age: 1,
        sex: ''
      }
      this.tableLabel = [
        {
          prop: 'nurse_ID',
          label: '员工编号'
        },
        {
          prop: 'nurse_name',
          label: '员工姓名'
        },
        {
          prop: 'nurse_dept',
          label: '科室'
        },
        {
          prop: 'nurse_position',
          label: '职位'
          //width: 200
        },
        {
          prop: 'salary',
          label: '月薪'
          //width: 200
        },
        {
          prop: 'age',
          label: '年龄'
        },
        {
          prop: 'sex',
          label: '性别'
        }
      ]
      this.getList()
      return true
    },
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
      if (this.tabletype === 1) {
        this.$http
          .get('https://localhost:44347/Doctor/Display', {
            params: {
              page: this.config.page
            }
          })
          .then(res => {
            //对性别数据二次处理
            console.log(res.data)
            this.tableData = res.data //.map(item => {
            // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
            //return 形成一个数组返回，item是一个数组
            //return item
            //})
            this.config.total = res.data.count
            this.config.loading = false
          })
      } else if (this.tabletype === 0) {
        this.$http
          .get('https://localhost:44347/Nurse/Display', {
            params: {
              page: this.config.page
            }
          })
          .then(res => {
            //对性别数据二次处理
            console.log(res.data)
            this.tableData = res.data //.map(item => {
            // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
            //return 形成一个数组返回，item是一个数组
            //return item
            //})
            this.config.total = res.data.count
            this.config.loading = false
          })
      }
    },
    // getList() {
    //   // 先设置加载状态
    //   // monn=
    //   this.config.loading = true
    //   this.$http
    //     .get('/api/user/getUser', {
    //       params: {
    //         page: this.config.page
    //       }
    //     })
    //     .then(res => {
    //       //对性别数据二次处理
    //       this.tableData = res.data.list //.map(item => {
    //       // item.sexLabel = item.sex === 0 ? '啥东西啊' : '哈药六厂'
    //       //return 形成一个数组返回，item是一个数组
    //       //return item
    //       //})
    //       this.config.total = res.data.count
    //       this.config.loading = false
    //     })
    // },
    editUser(row) {
      this.operateType = 'edit'
      this.isShow = true
      this.operateForm = row
    },
    confirm() {
      if (this.operateType === 'edit') {
        //post将数据传递过去，用then输出这个结果then(res => {console.log(res.data)
        this.$http.post('./api/user/sedit', this.operateForm).then(res => {
          console.log(res.data)
          this.isShow = false
          //重新获取数据，达到刷新效果
          this.getList()
        })
      } else if (this.operateType === 'add') {
        this.$http.post('/api/user/sadd', this.operateForm).then(res => {
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
      })
        .then(() => {
          let mid = {
            ID: row.ID
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
      // .then(() => {
      //   let id = row.id
      //   let parID = row.ID
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
      //     .get('/api/user/sdel', {
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
        ID: this.ID,
        name: this.name,
        dept: this.dept,
        position: this.position,
        salary: this.salary,
        age: this.age,
        sex: this.sex
      }
      this.operateType = 'add'
      this.isShow = true
    },
    searchUser() {
      this.config.loading = true
      // eslint-disable-next-line no-unused-vars
      let mid = {
        doctor_ID: this.searchForm.keyword
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
        .post('https://localhost:44347/Doctor/Query', mid)
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
  changeplaceholder() {
    this.placeholder = '很多钱'
    //this.el-image__placeholder="好吧"
  },
  created() {
    axios.post('https://localhost:44347/Doctor/RtSalary', {}).then(res => {
      this.countmoney = [
        {
          model: 'expend',
          alexpend: 0,
          waitexpend: res.data
        }
      ]
    })
    // this.countmoney = [
    //   {
    //     model: 'expend',
    //     alexpend: 50000,
    //     waitexpend: 510000
    //   }
    // ]
    this.getList()
  }
}
</script>

<style lang="scss" scoped>
@import '@/assets/scss/common';
</style>
