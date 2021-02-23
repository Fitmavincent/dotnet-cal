import { mapGetters, mapActions } from 'vuex';

export default {
  computed: {
    ...mapGetters({
      accessToken: 'user/getAccessToken',
      refreshToken: 'user/getRefreshToken',
      username: 'user/getUsername',
      role: 'user/getRole',
    })
  },
  methods: {
    ...mapActions({
      authorizeUser: 'user/authorizeUser',
      unauthorizeUser: 'user/unauthorizeUser',
    })
  }
}