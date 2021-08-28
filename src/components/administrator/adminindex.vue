<template>
  <div class="w">
    <div class="head">
      <div class="fl">欢迎你！{{this.$store.state.loginuid}}</div>
    </div>
    <tab path="/adminindex/Calendarpage">
      <div slot="text">
        <router-link to="/adminindex/Calendarpage">消费记录</router-link>
      </div>
      
    </tab>
    <tab path="/adminindex/Commodity">
      <div slot="text">
        <router-link to="/adminindex/Commodity">商品</router-link>
      </div>
    </tab>
    <!-- <router-link to="/adminindex/Calendarpage">消费记录</router-link> -->
    <!-- <router-link to="/adminindex/Commodity">商品</router-link> -->
    <router-view></router-view>
  </div>
</template>

<script>
import Tab from "./tab";
export default {
  name: "adminindex",
  components: {
    Tab,
  },
};
</script>

<style scoped>
.w {
  width: 800px;
  margin: 0 auto;
}
.head {
  width: 100%;
  height: 31px;
  background-color: #f1f1f1;
  line-height: 31px;
}
.fl {
  float: left;
}
.tabs {
  width: 100%;
  height: 40px;
  background-color: #c81623;
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