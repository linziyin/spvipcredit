<template>
<div class="w">
    <inquirebox1/>
    <inquirebox2/>
    <back-top @click.native="backClick" v-show="isShowBackTop"></back-top>

</div>
</template>

<script>
import inquirebox1 from './inquirebox1'
import inquirebox2 from './inquirebox2'
import BackTop from "../backtop/BackTop";

export default {
   name: "inquirebox",
   components:{
       inquirebox1,
       inquirebox2,
       BackTop
   },
   data() {
     return {
       isShowBackTop:true
     }
   },
   methods:{
     backClick() {
      window.scrollTo(0, 0, 500);
    },
   }
}
</script>

<style scoped>
.w {
  width: 800px;
  margin: 0 auto;
}
</style>
