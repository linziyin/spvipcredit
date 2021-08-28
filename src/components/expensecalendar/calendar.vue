<template>
  <div class="w">
    <div class="shortcut">
      <div class="w">
        <ul>
          <li class="fl">欢迎您！{{ this.$store.state.loginuid }}</li>
          <li class="fr"><a href="#" @click="backClick">返回</a></li>
        </ul>
      </div>
    </div>
    <div class="car-header">
      <div class="w">
        <div class="car-logo">
          <b>个人消费记录</b>
        </div>
      </div>
    </div>
    <div class="c-container">
      <div class="w">
        <div class="cart-filter-bar">
          <em>全部记录</em>
        </div>
        <!-- 消费记录主要核心区域 -->
        <div class="cart-warp">
          <!-- 头部全选模块 -->
          <div class="cart-thead">
            <div class="t-goods">商品</div>
            <div class="t-num">数量</div>
            <div class="t-sum">小计</div>
          </div>
          <!-- 商品详细模块
                <div class="cart-item-list">
                    <slot></slot>
                </div> -->
        </div>
      </div>
    </div>
    <calendarbox
      v-for="(items, index) in getpList"
      :key="index"
      :order-item="items"
    ></calendarbox>
    <!-- {{orderList}} -->
  </div>
</template>

<script>
import calendarbox from "./calendarbox";
import { mapGetters } from "vuex";

export default {
  name: "calendar",
  components: {
    calendarbox,
  },
  computed: {
    ...mapGetters(["getpList"]),
  },
  methods:{
    backClick(){
      this.$router.back(-1)
    }
  }
};
</script>

<style scoped>
li {
  list-style: none;
}
.fl {
  float: left;
  margin-left: 10px;
}

.fr {
  float: right;
  margin-right: 10px;
}
/*版心*/

.w {
  width: 700px;
  margin: 0 auto;
}

.style-red {
  color: #c81623;
}

.spacer {
  width: 1px;
  height: 12px;
  background-color: #666;
  margin: 9px 12px 0;
}

.shortcut {
  height: 31px;
  background-color: #f1f1f1;
  line-height: 31px;
}

.car-header {
  padding: 20px 0;
}

.car-logo img {
  vertical-align: middle;
}

.car-logo b {
  font-size: 20px;
  margin-top: 20px;
  margin-left: 10px;
}

.cart-filter-bar {
  font-size: 16px;
  color: #e2231a;
  font-weight: 700;
}

.cart-filter-bar em {
  padding: 5px;
  border-bottom: 1px solid #e2231a;
}

.cart-thead {
  height: 32px;
  line-height: 32px;
  margin: 5px 0 10px;
  padding: 5px 0;
  background: #f3f3f3;
  border: 1px solid #e9e9e9;
  border-top: 0;
  position: relative;
}

.cart-thead > div {
  float: left;
}

.t-checkbox,
.p-checkbox {
  height: 18px;
  line-height: 18px;
  padding-top: 7px;
  width: 122px;
  padding-left: 11px;
}

.t-goods {
  width: 400px;
}

.t-price {
  width: 120px;
  padding-right: 40px;
  text-align: right;
}

.t-num {
  width: 150px;
  text-align: center;
}

.t-sum {
  width: 85px;
  text-align: right;
}

.t-action {
  width: 130px;
  text-align: right;
}

/* 结算模块 */

.cart-floatbar {
  height: 50px;
  border: 1px solid #f0f0f0;
  background: #fff;
  position: relative;
  margin-bottom: 50px;
  line-height: 50px;
}

.select-all {
  float: left;
  height: 18px;
  line-height: 18px;
  padding: 16px 0 16px 9px;
  white-space: nowrap;
}

.select-all input {
  vertical-align: middle;
  display: inline-block;
  margin-right: 5px;
}

.operation {
  float: left;
  width: 200px;
  margin-left: 40px;
}

.clear-all {
  font-weight: 700;
  margin: 0 20px;
}

.toolbar-right {
  float: right;
}

.amount-sum {
  float: left;
}

.amount-sum em {
  font-weight: 700;
  color: #e2231a;
  padding: 0 3px;
}

.price-sum {
  float: left;
  margin: 0 15px;
}

.price-sum em {
  font-size: 16px;
  color: #e2231a;
  font-weight: 700;
}

.btn-area {
  font-weight: 700;
  width: 94px;
  height: 52px;
  line-height: 52px;
  color: #fff;
  text-align: center;
  font-size: 18px;
  font-family: "Microsoft YaHei";
  background: #e54346;
  overflow: hidden;
}
</style>