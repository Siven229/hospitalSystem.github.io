<template>
  <el-menu
    router
    default-active="2"
    class="el-menu-vertical-demo"
    background-color="#545c64"
    text-color="#fff"
    active-text-color="#ffd04b"
    :collapse="isCollapse"
  >
    <h3 v-show="!isCollapse">管理系统</h3>
    <h3 v-show="isCollapse">eSun</h3>
    <el-menu-item
      :index="item.path"
      v-for="item in noChildren"
      :key="item.path"
      @click="clickMenu(item)"
    >
      <i :class="`el-icon-${item.icon}`"></i>
      <span slot="title">{{ item.label }}</span>
    </el-menu-item>
    <el-submenu index="index" v-for="(item, index) in hasChildren" :key="index">
      <template slot="title">
        <i :class="`el-icon-${item.icon}`"></i>
        <span slot="title">{{ item.label }}</span>
      </template>
      <el-menu-item-group>
        <el-menu-item
          :index="subItem.path"
          v-for="(subItem, subIndex) in item.children"
          :key="subIndex"
          @click="clickMenu(subItem)"
        >
          <i :class="`el-icon-${subItem.icon}`"></i>
          <span slot="title">{{ subItem.label }}</span>
        </el-menu-item>
      </el-menu-item-group>
    </el-submenu>
  </el-menu>
</template>

<script>
export default {
  data() {
    return {
      asideMenu: [
        {
          path: '/',
          name: 'home',
          label: '首页',
          icon: 'home' //图标
        },
        {
          path: '/medicine',
          name: 'medicine',
          label: '药品管理',
          icon: 'user'
          // url: 'UserManage/UserManage'
          // children: [
          //   {
          //     path: '/user',
          //     name: 'user',
          //     label: '药品管理',
          //     icon: 'setting'
          //     //url: 'UserManage/UserManage'
          //   },
          //   {
          //     path: '/Prescription',
          //     name: 'Prescription',
          //     label: '处方单',
          //     icon: 'setting'
          //     // url: 'UserManage/Prescription'
          //   }
          // ]
        },
        {
          // path: '/video',
          // name: 'video',
          label: '财务管理',
          icon: 'location',
          children: [
            {
              path: '/salary',
              name: 'salary',
              label: '员工工资页',
              icon: 'setting'
            },
            {
              path: '/bill',
              name: 'bill',
              label: '病人账单页',
              icon: 'setting'
            }
          ]
        }
        // {
        //   // 二级菜单中一级菜单无需跳转，故可省略path
        //   label: '其他管理',
        //   icon: 'user',
        //   children: [
        //     {
        //       path: '/page1',
        //       name: 'page1',
        //       label: '页面1',
        //       icon: 'setting'
        //     },
        //     {
        //       path: '/page2',
        //       name: 'page2',
        //       label: '页面2',
        //       icon: 'setting'
        //     }
        //   ]
        // }
      ]
    }
  },
  computed: {
    noChildren() {
      return this.menu.filter(item => !item.children)
    },
    hasChildren() {
      return this.menu.filter(item => item.children)
    },
    isCollapse() {
      return this.$store.state.tab.isCollapse
    },
    menu() {
      return this.$store.state.tab.menu
    }
  },
  methods: {
    clickMenu(item) {
      // 设置路由跳转
      this.$router.push({ name: item.name })
      this.$store.commit('selectMenu', item)
    }
  }
}
</script>

<style lang="scss" scoped>
.el-menu {
  height: 100%;
  border: none;
  h3 {
    color: #fff;
    text-align: center;
    line-height: 48px;
  }
}
.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
</style>
