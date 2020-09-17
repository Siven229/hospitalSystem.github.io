<template>
  <div class="common-table">
    <el-table :data="tableData" height="90%" stripe v-loading="config.loading">
      <el-table-column label="编号" width="100">
        <!-- 这个template就是一个插槽; 通过作用域插槽可以使用外部变量  -->
        <!--这个下面就是计算序号的地方，后续修改 -->
        <template slot-scope="scope">
          <span style="margin-left: 10px">{{
            (config.page - 1) * 20 + scope.$index + 1
          }}</span>
        </template>
      </el-table-column>
      <el-table-column
        show-overflow-tooltip
        v-for="item in tableLabel"
        :key="item.prop"
        :label="item.label"
        :width="item.width ? item.width : 125"
      >
        <!-- 这个template就是一个插槽; 通过作用域插槽可以使用外部变量  -->
        <template slot-scope="scope">
          <span style="margin-left: 10px">{{ scope.row[item.prop] }}</span>
        </template>
      </el-table-column>
      <!-- <el-table-column label="工资数" width="180">
        <<template slot-scope="scope">
        </template>
      </el-table-column> -->
      <el-table-column label="操作" width="180">
        <!-- <template slot-scope="scope"> -->
        <template slot-scope="">
          <el-button size="mini" type="primary" @click="handle_type"
            >支付薪水</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <!-- pagination就是分页的那个样式-->
    <el-pagination
      class="pager"
      layout="prev, pager, next"
      :total="config.total"
      :current-page.sync="config.page"
      @current-change="changePage"
    ></el-pagination>
    <!-- 通过.sync实现双向绑定数据 -->
  </div>
</template>

<script>
export default {
  props: {
    tableData: Array,
    tableLabel: Array,
    // 接受其他配置
    config: Object
  },
  methods: {
    // handleEdit(row) {
    //   this.$emit('edit', row)
    // },
    // handleDelete(row) {
    //   this.$emit('del', row)
    // },
    changePage(page) {
      this.$emit('changePage', page)
    },
    handle_type(row) {
      this.$emit('zhifu', row)
      // 禁用点击事件
      // this.disabled = 'true'
      // // 提交业务
      // // 10秒后启用点击事件
      // setTimeout(function() {
      //   this.disabled = 'false'
      // }, 10000)
    }
  }
}
</script>

<style lang="scss" scoped>
.common-table {
  height: calc(100% - 62px);
  background-color: #fff;
  position: relative;
  .pager {
    position: absolute;
    bottom: 0;
    right: 20px;
  }
}
</style>
