<template>
  <div class="w">
    <include-box></include-box>
    <inquire-box></inquire-box>
  </div>
</template>

<script>
import IncludeBox from './includebox'
import InquireBox from './inquirebox'
export default {
  name: "calendarpage",
  components:{
     IncludeBox,
     InquireBox
  }
};
</script>

<style scoped>
.w {
  width: 800px;
  margin: 0 auto;
}
</style>