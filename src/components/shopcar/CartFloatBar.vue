<template>
  <div class="cart-floatbar">
    <div class="select-all">
      <check-button
        class="check-button"
        :is-checked="isSelectAll"
        @click.native="checkClick"
      ></check-button>
      <!-- <check-button class="check-button"></check-button>   -->
      <span>全选</span>
    </div>

    <div class="toolbar-right">
      <div class="amount-sum">
        已经选<em>{{ checkLength }}</em
        >件商品
      </div>
      <div class="price-sum">
        总价： <em>{{ totalCredit }}</em>
      </div>
      <button class="btn-area" @click="calClick">去结算</button>
    </div>
    <toast :message="showbuy" :is-show="show"></toast>
    <!-- <button @click="addDate">获取时间</button>
{{updateTime}} -->
  </div>
</template>

<script>
import CheckButton from "../checkButton/CheckButton";
import toast from "../toast/Toast";

import { mapActions, mapGetters } from "vuex";

export default {
  name: "CartFloatBar",
  components: {
    CheckButton,
    toast,
  },
  data() {
    return {
      updateTime: "",
      updateOrder: "",
      showbuy: "",
      show: false,
      // remainCredit: 0,
      // OrderProduct: [],
    };
  },
  computed: {
    ...mapGetters(["cartList"], ["orderList"],["loginuid"]),
    isSelectAll() {
      for (let item of this.cartList) {
        if (item.pchecked == "false") {
          return "false";
        }
      }
      return "true";
      // console.log("isSelectAll")
      // console.log(this.cartList.filter(item => item.checked).length)
      // if (this.cartList.length === 0) return false;
      // else return !this.cartList.find((item) => !item.checked);
      //    else return !(this.cartList.filter(item => !item.checked).length)
    },
    checkLength() {
      return this.cartList.filter((item) => item.pchecked == "true").length;
    },
    totalCredit() {
      return this.cartList
        .filter((item) => {
          return item.pchecked == "true";
        })
        .reduce((preValue, item) => {
          return preValue + item.pnewCredit;
        }, 0)
        .toFixed(2);
    },
  },
  methods: {
    ...mapGetters(["usercredit"]),
    ...mapActions(["achanguidcredit"]),
    checkClick() {
      if (this.isSelectAll == "true") {
        this.cartList.forEach((item) => (item.pchecked = "false"));
      } else this.cartList.forEach((item) => (item.pchecked = "true"));
    },
    addDate() {
      const nowDate = new Date();
      const date = {
        // yy: nowDate.getFullYear(),
        MM: nowDate.getMonth() + 1,
        DD: nowDate.getDate(),
        hh: nowDate.getHours(),
        mm: nowDate.getMinutes(),
        ss: nowDate.getSeconds(),
      };
      const newmonth = date.MM > 10 ? date.MM : "0" + date.MM;
      const newday = date.DD > 10 ? date.DD : "0" + date.DD;
      const newhour = date.hh > 10 ? date.hh : "0" + date.hh;
      const newminute = date.mm > 10 ? date.mm : "0" + date.mm;
      const newseconds = date.ss > 10 ? date.ss : "0" + date.ss;

      this.updateOrder = newmonth + newday + newhour + newminute + newseconds;
      this.updateTime =
        newmonth +
        "-" +
        newday +
        " " +
        date.hh +
        ":" +
        newminute +
        ":" +
        newseconds;
    },
    addOrder() {
      // var thisVue=this;
      this.$http
        .get(
          "https://localhost:44339/api/Users/AddOrder/?orderid=" +
            this.updateOrder +
            "&ordertime=" +
            this.updateTime +
            "&uid=" +
            this.$store.state.loginuid +
            ""
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("ordersuccess!!!!");
          }
        });
    },

    addOrderItem() {
      // var thisVue=this;
      console.log(this);
      this.$http
        .get(
          "https://localhost:44339/api/Users/AddOrderItem/?productid=" +
            order.orderitem[index].pid +
            "&orderid=" +
            this.updateOrder +
            "&count=" +
            order.orderitem[index].pcount +
            ""
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("orderitemsuccess!!!!");
          }
        });
    },
    calClick() {
      console.log(this.$store.state.uidcredit);
      if (parseFloat(this.totalCredit) <= this.$store.state.uidcredit) {
        console.log(parseFloat(this.totalCredit));
        // console.log("点击成功")
        //  this.$store.dispatch('achanguidcredit',parseFloat(this.totalCredit))
        this.achanguidcredit(parseFloat(this.totalCredit)).then((res) => {
          console.log(res);
          this.showbuy = "兑换成功，您的积分还剩下" + res;
          // console.log(this.loginuid)
          console.log(this.$store.state.loginuid)
          this.changeucredit(res,this.$store.state.loginuid)
          this.show = true;
          setTimeout(() => {
            this.show = false;
            this.showbuy = "";
          }, 2000); //显示toast

          this.addDate();
          this.addOrder();
          // this.addOrderItem();

          // 添加每个订单的商品
          const order = { orderid: "", ordertime: "", orderitem: [] };
          order.orderid = this.updateOrder;
          order.ordertime = this.updateTime;
          order.orderitem = this.cartList.filter(
            (item) => item.pchecked == "true"
          );
          for (var index in order.orderitem) {
            console.log(order.orderitem[index].pid);
            console.log(order.orderitem[index].pcount);
            console.log(this);
            this.$http
              .get(
                "https://localhost:44339/api/Users/AddOrderItem/?productid=" +
                  order.orderitem[index].pid +
                  "&orderid=" +
                  this.updateOrder +
                  "&count=" +
                  order.orderitem[index].pcount +
                  ""
              )
              .then((res) => {
                if (res.data > 0) {
                  console.log("orderitemsuccess!!!!");
                }
              });
          }
          // order.orderitem=[1,2,3,4];
          // console.log(order);
          // this.$store.commit("addToOrder", order);
          // console.log(this.$store.state.orderList);

          // this.addOrder();

          // var thisVue=this;
          // this.$http
          //   .get(
          //     "https://localhost:44339/api/Users/AddOrderItem/?productid=" +
          //       this.orderitem[0].pid +
          //       "&orderid=" +
          //       this.updateOrder +
          //       "&count=" +
          //       this.orderitem[0].pcount +
          //       ""
          //   )
          //   .then((res) => {
          //     if (res.data > 0) {
          //       console.log("success!!!!");
          //     }
          //   });

          //清空选择按钮和商品数量
          this.cartList.forEach((item) => (item.pchecked = "false"));
        });
        // console.log(this.$store.state.uidcredit)
      } else {
        this.showbuy = "兑换失败，您的积分不足以兑换所需商品";
        this.show = true;
        setTimeout(() => {
          this.show = false;
          this.showbuy = "";
        }, 2000);

        // this.addDate();
        // const order={orderid:'',ordertime:'',orderitem:[]};
        //   order.orderid=this.updateOrder;
        //   order.ordertime=this.updateTime;
        //   order.orderitem=this.cartList.filter(item =>item.pchecked=='true')
        //   // order.orderitem=[1,2,3,4];
        //   console.log(order);
        //   this.$store.commit('addOrder',order);
        //   console.log(this.$store.state.orderList);
        //    this.cartList.forEach(
        //     (item) => ((item.pchecked = "false"), (item.pcount = 1))
        //   );
        //清空选择按钮和商品数量
        // console.log("点击失败")
        // console.log(this.$store.state.uidcredit)
      }
    },
    changeucredit(ucredit,uid) {
      this.$http
        .get(
          "https://localhost:44339/api/Users/ChangeCredit/?usercredit=" +
            ucredit +
            "&userid=" +
            uid
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("changecreditsuccess!!!!");
          }
        });
    },
  },
};
</script>

<style scoped>
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
  display: flex;
}

.check-button {
  width: 22px;
  height: 22px;
  line-height: 20px;
  margin-right: 5px;
  margin-top: 0px;
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
