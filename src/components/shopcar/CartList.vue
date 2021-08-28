<template>
  <div class="cart-list">
    <!-- {{cartList}} -->
   <!-- <cart-list-item></cart-list-item> -->
   <cart-list-item v-for="(item,index) in cartList" :key="index" :item-info="item"></cart-list-item>
  </div>
</template>

<script>
import CartListItem from "./CartListItem";

import { mapGetters} from 'vuex'

export default {
  name: "CartList",
  components: {
    CartListItem,
  },
  // props:{
  //   products:{
  //     type:Array,
  //     default(){
  //       return []
  //     }
  //   }
  // }
  computed:{
       ...mapGetters(['cartList'])
   }
 
};
</script>

<style scoped>
</style>
