export const user = {
  namespaced: true,
  state: {
    access_token: "",
    refresh_token: "",
    username: "",
    role: "",
  },
  getters: {
    getAccessToken: state => {
      return state.access_token;
    },
    getRefreshToken: state => {
      return state.refresh_token;
    },
    getUsername: state => {
      return state.username;
    },
    getRole: state => {
      return state.role;
    }
  },
  mutations: {
    updateUser(state, user) {      
      state.access_token = user.access_token;
      state.refresh_token = user.refresh_token;
      state.username = user.username;
      state.role = user.role;
    },
    removeUser(state) {
      state.access_token = "";
      state.refresh_token = "";
      state.username = "";
      state.role = "";
    }
  },
  actions: {
    authorizeUser(context, user) {
      context.commit('updateUser', user);
    },
    unauthorizeUser(context) {
      context.commit('removeUser');
    }
  }
}