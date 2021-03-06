import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import store from './components/store'


Vue.config.productionTip = false
Vue.prototype.$http = axios;

new Vue({
  render: h => h(App),
  router,
  store,

}).$mount('#app')

