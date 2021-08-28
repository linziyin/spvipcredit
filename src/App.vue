<template>
  <div id="app">
     <!-- <shop-car>
       <car-item></car-item>
       <car-item></car-item>
       <car-item></car-item>
     </shop-car> -->
     <!-- <user-login></user-login> -->
     <!-- <adminindex></adminindex> -->
     <!-- {{this.$store.state.cartList}} -->
     <!-- {{this.$store.state.userList}} -->

     <router-view></router-view>
  </div>

</template>

<script>

export default {
  name: 'App',
  data() {
    return {
      getProducts:[],
      getUsers:[],
    }
  },
  mounted(){
    this.getProductList();
    this.getUserList();

  },
  methods:{
     getProductList(){
      var thisVue=this;
      this.$http.get('https://localhost:44339/api/Products/GetProducts').then(res=>{
        // console.log(res.data);
        res.data.map((item,index)=>{
          thisVue.getProducts.push(
            Object.assign(item,{pchecked:'false',pnewCredit:0,pcount:1})
          )
        });
        console.log(thisVue.getProducts)
        // thisVue.getProducts=res.data;
        
        this.$store.commit('addToCart',thisVue.getProducts)
        // console.log(this.$store.state.cartList)
      })
    },
    getUserList(){
      var thisVue=this;
      this.$http.get('https://localhost:44339/api/Users/GetUsers').then(res=>{
        thisVue.getUsers=res.data;

        this.$store.commit('addUserMessage',thisVue.getUsers)
        // console.log(this.$store.state.userList)
      })
    },
  }
}
</script>

<style>
@import "assets/css/base.css";
</style>
