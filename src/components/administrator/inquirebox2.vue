<template>
 <div>
     <query-box v-for="(item, index) in getpList"
      :key="index"
      :show-item="item"></query-box>
 </div>
</template>

<script>
import QueryBox from "./querybox";
import {mapGetters} from 'vuex'
export default {
   name: "inquirebox2",
   components:{
       QueryBox
   },
   computed:{
       ...mapGetters(['getpList']),
   },

}
</script>

<style scoped>

</style>
