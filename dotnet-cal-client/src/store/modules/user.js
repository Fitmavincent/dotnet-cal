export const user = {
  namespaced: true,
  state: {
    user: {}    
  },
  getters: {
    getAccessToken: state => {
      return state.user?.accessToken;
    },
    getRefreshToken: state => {
      return state.user?.refreshToken;
    },
    getUsername: state => {
      return state.user?.username;
    },
    getRole: state => {
      return state.user?.role;
    }
  },
  mutations: {
    updateUser(state, user) {
      if(user) state.user = user;
    },
    removeUser(state) {
      state.user = null;
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