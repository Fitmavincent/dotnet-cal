<template>
  <div>
    <el-row>
      <el-input v-model="num1"></el-input>
      <span>{{ arithmetic }}</span>
      <el-input v-model="num2"></el-input>
      <span> = </span>
      <span>{{ result }}</span>
    </el-row>

    <el-row>
      <el-button type="primary" @click="add">+</el-button>
      <el-button type="primary" @click="sub">-</el-button>
      <el-button type="primary" @click="multiply">*</el-button>
      <el-button type="primary" @click="divide">/</el-button>
    </el-row>

    <el-row>
      <el-button type="primary" @click="clear">Clear</el-button>      
    </el-row>

    <el-alert v-show="isError" :title="error" type="error" center show-icon></el-alert>

  </div>
</template>

<script>
export default {
  mixins: [],
  mounted() {
    console.log("Calculator Mounted", this.$store);
  },
  data() {
    return {
      num1: 0,
      num2: 0,
      arithmetic: "+",
      result: 0,
      error: "",
      isError: false,
    };
  },
  methods: {
    clear() {
      this.num1 = 0;
      this.num2 = 0;
      this.result = 0;
    },
    add() {      
      this.arithmetic = "+";
      this.getResult(`${process.env.VUE_APP_API_URL}/arithmetic/add`);
    },
    sub() {      
      this.arithmetic = "-";
      this.getResult(`${process.env.VUE_APP_API_URL}/arithmetic/sub`);
    },
    multiply() {
      this.arithmetic = "*";
      this.getResult(`${process.env.VUE_APP_API_URL}/arithmetic/multiply`);
    },
    divide() {      
      this.arithmetic = "/";
      this.getResult(`${process.env.VUE_APP_API_URL}/arithmetic/divide`);
    },
    getResult(url){
      this.isError = false;
      window.axios.get(url, {
        params: { num1: this.num1, num2: this.num2 }
      }).then((response) => {
        this.result = response.data;
      }).catch((error) => {
        this.isError = true;
        if(error.response?.data) {
          this.error = error.response.data?.title;
        }
      })
    }
  }
}
</script>

<style scoped>
.el-input {
  min-width: 60px;
  max-width: 120px;
  margin: 0 20px 0 20px;
}
.el-button {
  min-width: 100px;
}
.el-row {
  line-height: 80px;
}
</style>