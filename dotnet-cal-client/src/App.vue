<template>
  <div id="app">
    <el-container>
      <el-header height="60px"></el-header>
      <el-main>
        <Calculator />
        <Login />
      </el-main>      
      <el-footer height="60px"></el-footer>
    </el-container>    
  </div>
</template>

<script>
import Calculator from './components/Calculator.vue'

export default {
  components: { Calculator },
  name: 'App',  
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
