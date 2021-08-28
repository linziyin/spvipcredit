<template>
  <div class="rl" :class="{ active: this.isActive }">
    <slot name="text"></slot>
  </div>
</template>

<script>
export default {
  name: "tab",
  props: {
    path: String,
    activeColor: {
      type: String,
      default: "red",
    },
  },
  computed: {
    isActive() {
      return this.$route.path.indexOf(this.path) !== -1;
    },
    // activeStyle(){
    //     return this.isActive? {color:this.activeColor}:{}
    // }
  },
  methods: {
    // itemClick() {
    //   this.$router.push(this.path);
    // },
  },
};
</script>

<style scoped>
.rl {
  display: inline-block;
  width: 397px;
  height: 40px;
  text-align: center;
  font-size: 17px;
  line-height: 40px;
  border-bottom: 2px solid #c81623;
  /* background-color: #c81623; */
  color: #f1f1f1;
  margin-top: 10px;
}
.active {
  background-color: white;
  color: #000;
  border-width: 2px 2px 0 2px;
  border-style: solid;
  border-color: #c81623;
}
</style>