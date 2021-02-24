<template>
  <div class="login">
    <el-form label-position="right" label-width="100px" :model='form'>
      <el-form-item label="Username">
        <el-input v-model="form.username"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="form.password"></el-input>
      </el-form-item>      

      <el-alert v-show="isError" :title="error" type="error" center show-icon></el-alert>

      <el-form-item>
        <el-button type="primary" @click=onSubmit>Login</el-button>
      </el-form-item>
    </el-form>

    
  </div>
</template>

<script>
export default {
  mixins: [],
  mounted() {
    console.log("Login mounted", this.$store);
  },
  data() {
    return {
      form: {
        username: '',
        password: '',
      },
      error: '',
      isError: false,
    };
  },
  methods: {
    onSubmit(e){
      this.isError = false;
      e.preventDefault();      
      window.axios.post('http://localhost:5000/api/user/login', {
        username: this.form.username,
        password: this.form.password,
      }).then((response) => {
        this.authorizeUser(response.data);
        this.setHeader();
      }).catch((error) => {
        if(error.response?.data) {
          this.isError = true;
          this.error = error.response.data?.title;
        }        
      })
    },
    setHeader() {
      console.log(this.accessToken);
      if (this.accessToken) {
        window.axios.defaults.headers.common = {
          Authorization: `bearer ${this.accessToken}`,
          Accept: `application/json`,
        };
      }
    },
  }
}
</script>

<style scoped>
.login {
  display: flex;
  justify-content: center;
  align-content: stretch;  
}

.el-form {
  min-width: 400px;
  max-width: 500px;
}

.el-alert {
  height: 30px;
}


</style>