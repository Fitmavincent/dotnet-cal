<template>
  <div id="app">
    <el-container>
      <el-header height="60px">
        <el-menu v-if="accessToken" mode="horizontal">
          <el-submenu index="1">
            <template slot="title">{{ username }}</template>
            <el-menu-item index="1-1">{{ role }}</el-menu-item>
            <el-menu-item index="1-2" @click="logout">Logout</el-menu-item>
          </el-submenu>
        </el-menu>
      </el-header>

      <el-main>
        <Calculator v-if="accessToken"/>
        <Login v-if="!accessToken"/>
      </el-main>      

      <el-footer height="60px"></el-footer>
    </el-container>    
  </div>
</template>

<script>

export default { 
  name: 'app', 
  mounted() {    
    
  },
  methods: {
    logout() {
      this.unauthorizeUser();
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  padding: 0;  
}

.el-header {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

.el-main {
  background-color: #E9EEF3;
  color: #333;
  text-align: center;
  line-height: 160px;
}

.el-footer {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}
</style>
