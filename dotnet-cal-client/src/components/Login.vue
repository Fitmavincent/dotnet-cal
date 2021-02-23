<template>
  <el-container type="flex" justify="center">
    <el-form label-position="right" label-width="100px" class="login" :model='form'>
      <el-form-item label="Username">
        <el-input v-model="form.username"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click=onSubmit>Login</el-button>
      </el-form-item>
    </el-form>
  </el-container>  
</template>

<script>
import axios from 'axios';

export default {
  mixins: [],
  mounted() {
    
  },
  data() {
    return {
      form: {
        username: '',
        password: '',
      },
    };
  },
  methods: {
    onSubmit(e){
      e.preventDefault();
      axios.post('http://localhost:5000/api/user/login', {
        username: this.form.username,
        password: this.form.password,
      }).then((response) => {
        this.authorizeUser(response.data);
      }).catch((error) => {
        console.error(error);
      })
    },
    setHeader() {
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
    width: 350px;
    height: 300px;
    padding: 20px;
  }


</style>