import Vue from 'vue'
import App from './App.vue'
import store from './store';
import ElementUI from 'element-ui';
import globalMixin from './mixins/globalMixin'
import 'element-ui/lib/theme-chalk/index.css';


Vue.use(ElementUI);
Vue.mixin(globalMixin);
Vue.config.productionTip = false

const files = require.context('./', true, /\.vue$/i);
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default)); 

new Vue({
  render: h => h(App),
  store: store
}).$mount('#app')
