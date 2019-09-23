
import Vue from 'vue'
import App from './App'
/* import router from './router' */
import axios from 'axios'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
/* import '@fortawesome/fontawesome-free/css/all.css'  */
 
Vue.config.productionTip = false
 
// Setup axios as the Vue default $http library
axios.defaults.baseURL = 'http://localhost:5000' // same as the Url the server listens to
Vue.prototype.$http = axios
 
// Install Vue extensions
Vue.use(BootstrapVue)
 
new Vue({  
  render: h => h(App)
}).$mount('#app')
