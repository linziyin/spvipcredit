<template>
  <div class="include">
    <div class="title">添加会员消费记录</div>
    <div class="ad_form">
      <form action="">
        <ul>
          <li>
            <label for="">订单号：</label>
            <input type="text" class="inp" v-model.lazy="orderid" />
          </li>
          <li>
            <label for="">用户账号：</label>
            <input type="text" class="inp" v-model.lazy="userid" />
          </li>
          <li>
            <label for="">商品编号：</label>
            <input type="text" class="inp" v-model.lazy="productid" />
          </li>
          <li>
            <label for="">数量：</label>
            <input type="text" class="inp" v-model.lazy="productnumber" />
          </li>
        </ul>
      </form>
      <div class="btn" @click="btnClick">确认添加</div>
      <toast :message="showmessage" :is-show="show"></toast>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import toast from "../toast/Toast";

export default {
  name: "includebox",
  components: {
    toast,
  },
  data() {
    return {
      orderid: "",
      userid: "",
      productid: "",
      productnumber: "",
      ordertime: "",
      showmessage: "",
      show: false,
      User: {},
      product: {},
      ujifen: 0,
      pjifen: 0,
      userNewCredit:0
    };
  },
  computed: {
    ...mapGetters(["userList"]),
  },
  methods: {
    btnClick() {
      this.addOrder();
      this.addOrderItem();
      // this.showmessage="添加成功"
      // this.show=true
      // setTimeout(() => {
      //     this.show=false;
      //     this.showmessage='';
      // }, 2000);
      // console.log(this.userList)
      // const user=this.userList.find(item=>item.uid==this.userid)
      // console.log(user)
      // console.log(user.ucredit)
      // console.log(this.$store.state.userList)

      // this.GetUserByUId(this.userid)
      // this.getProductById(this.productid)
      // this.userNewCredit=this.userid.ucredit+this.product.pcredit
      // this.UserNewCredit1();
      // console.log(this.totaljifen)
      // this.changeucredit(this.totaljifen,this.userid)

      Promise.all([
        this.getProductById(this.productid),
        this.GetUserByUId(this.userid),
      ]).then((res) => {
        console.log(res[0] + res[1]);
        this.userNewCredit = res[0] + res[1];
        console.log(this.userNewCredit);
        this.changeucredit(this.userNewCredit, this.userid);
      });
      this.showmessage = "添加成功";
      this.show = true;
      setTimeout(() => {
        this.show = false;
        this.showmessage = "";
      }, 2000);
    },
    addOrder() {
      // var thisVue=this;

      this.ordertime =
        this.orderid.substring(0, 2) +
        "-" +
        this.orderid.substring(2, 4) +
        " " +
        this.orderid.substring(4, 6) +
        ":" +
        this.orderid.substring(6, 8) +
        ":" +
        this.orderid.substring(8, 10);

      this.$http
        .get(
          "https://localhost:44339/api/Users/AddOrder/?orderid=" +
            this.orderid +
            "&ordertime=" +
            this.ordertime +
            "&uid=" +
            this.userid +
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
            this.productid +
            "&orderid=" +
            this.orderid +
            "&count=" +
            this.productnumber +
            ""
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("orderitemsuccess!!!!");
          }
        });
    },
    GetUserByUId(uid) {
      return new Promise((resolve, reject) => {
        var thisVue = this;
        this.$http
          .get("https://localhost:44339/api/Users/GetUserByUId?uid=" + uid)
          .then((res) => {
            console.log(res.data);
            thisVue.User = res.data;
            console.log(this.User);
            console.log(this.User.ucredit);
            this.ujifen = this.User.ucredit;
            resolve(this.ujifen);
          });
      });
    },
    getProductById(pid) {
      return new Promise((resolve, reject) => {
        var thisVue = this;
        this.$http
          .get(
            "https://localhost:44339/api/Products/GetProductAllById?pid=" + pid
          )
          .then((res) => {
            thisVue.product = res.data;
            console.log(this.product);
            console.log(this.product.pcredit);
            this.pjifen = this.product.pcredit;
            resolve(this.pjifen);
          });
      });
    },
    UserNewCredit1() {
      this.userNewCredit = this.userid.ucredit + this.product.pcredit;
      console.log(this.userNewCredit);
    },
    changeucredit(ucredit, uid) {
      this.$http
        .get(
          "https://localhost:44339/api/Users/ChangeCredit/?usercredit=" +
            ucredit +
            "&userid=" +
            uid
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("addcreditsuccess!!!!");
          }
        });
    },
  },
};
</script>

<style scoped>
.include {
  margin-top: 10px;
  border: 1px solid #aaa;
  border-radius: 10px;
}
.include .title {
  font-size: 18px;
  border-bottom: 1px solid #aaa;
  padding: 5px 5px;
}
.ad_form {
  margin-top: 20px;
  overflow: hidden;
  margin-left: 50px;
}
.ad_form ul li {
  margin-bottom: 20px;
  float: left;
}
.ad_form ul li label {
  display: inline-block;
  width: 88px;
  text-align: right;
}
.ad_form ul li .inp {
  width: 242px;
  height: 37px;
  border: 1px solid #ccc;
}
.btn {
  cursor: pointer;
  float: left;
  width: 200px;
  height: 34px;
  background-color: #c81623;
  font-size: 14px;
  color: #fff;
  margin-left: 240px;
  margin-bottom: 20px;
  text-align: center;
  line-height: 34px;
}
</style>>