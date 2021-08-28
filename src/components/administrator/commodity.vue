<template>
  <div class="w">
    <!-- 查找编辑操作栏开始 -->
    <div class="com-head">
      <div>
        <a href="#" class="btnall" @click="showClick">显示全部</a>
      </div>
      <div class="com-search">
        <input
          type="text"
          value="请输入商品货号"
          class="c-search"
          v-model.lazy="proid"
        />
        <div class="btn-search" @click="searchClick(proid)">查找</div>
      </div>
    </div>
    <!-- 查找编辑操作栏结束 -->
    <!-- 商品属性栏开始 -->
    <div class="com-thead">
      <ul class="com-property">
        <li class="c-goods">商品</li>
        <li class="c-id">货号</li>
        <li class="c-price">积分</li>
        <li class="c-brand">品牌</li>
        <li class="c-pArea">产地</li>
        <li class="c-category">类别</li>
      </ul>
    </div>
    <!-- 商品属性栏结束 -->
    <!-- 商品详细内容开始 -->
    <div class="com-content">
      <!-- 五个商品 -->
      <commodity-item
        v-for="(item, index) in cartList1"
        :key="index"
        :item-info="item"
      ></commodity-item>
    </div>
    <!-- 商品详细内容结束 -->

    <!-- 添加删除操作开始 -->
    <div class="add_del">
      <div class="select-all">
        <check-button
          class="check-button"
          :is-checked="isSelectAll"
          @click.native="checkClick"
        ></check-button>
        <!-- <check-button class="check-button"></check-button>   -->
        <span>全选</span>
      </div>
      <div class="add" @click="addclick">添加商品</div>
      <div class="del" @click="delClick">删除商品</div>
    <back-top @click.native="backClick" v-show="isShowBackTop"></back-top>

    </div>
    <!-- 添加删除操作结束 -->
  </div>
</template>

<script>
import CommodityItem from "./commodityitem";
import CheckButton from "../checkButton/CheckButton";
import BackTop from "../backtop/BackTop";

import { mapGetters } from "vuex";
export default {
  name: "commodity",
  data() {
    return {
      proid: "",
      getProducts: [],
      product: [],
      deleteList:[],
      isShowBackTop: true,
    };
  },

  components: {
    CheckButton,
    CommodityItem,
    BackTop
  },
  mounted() {
    this.getProductList1();
  },
  computed: {
    ...mapGetters(["cartList1"]),
    isSelectAll() {
      for (let item of this.cartList1) {
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
  },
  methods: {
    backClick() {
      window.scrollTo(0, 0, 500);
    },
    addclick() {
      this.$router.push("/ComAddGoods");
    },
    checkClick() {
      if (this.isSelectAll == "true") {
        this.cartList1.forEach((item) => (item.pchecked = "false"));
      } else this.cartList1.forEach((item) => (item.pchecked = "true"));
    },
    showClick(){
      this.getProductList1();
    },
    searchClick(pid) {
      // console.log(this.cartList1)
      // const product=this.cartList1.filter(item=>item.pid==1001)
      // console.log(product)
      this.getProductById(pid);
    },
    delClick(){
      this.deleteList=[];
      this.deleteList=this.cartList1.filter(
        (item) => item.pchecked == "true"
      )
      console.log(this.deleteList)
      for(var index in this.deleteList){
        this.DeleteProductItem(this.deleteList[index].pid)
      }
      
    },
    getProductList1() {
      var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Products/GetProductListAll")
        .then((res) => {
          console.log(res.data);
          thisVue.getProducts=[];
          res.data.map((item, index) => {
            thisVue.getProducts.push(
              Object.assign(item, {
                pchecked: "false",
                pnewCredit: 0,
                pcount: 1,
              })
            );
          });
          console.log(thisVue.getProducts);
          // thisVue.getProducts=res.data;

          this.$store.commit("addToCart1", thisVue.getProducts);
          console.log(this.cartList1);
        });
    },
    getProductById(pid) {
      var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Products/GetProductById1?pid=" + pid)
        .then((res) => {
          thisVue.product=[];
          res.data.map((item, index) => {
            thisVue.product.push(
              Object.assign(item, {
                pchecked: "false",
                pnewCredit: 0,
                pcount: 1,
              })
            );
          });
          // thisVue.product=res.data;
          console.log(this.product);
          this.$store.commit("addToCart1", thisVue.product);
          console.log(this.cartList1);
        });
    },
    DeleteProductItem(pid) {
      // var thisVue=this;
      this.$http
        .get(
          "https://localhost:44339/api/Products/DeleteProductItem/?productid=" + pid
        )
        .then((res) => {
          // console.log(res.data);
          if (res.data > 0) {
            console.log("deleteproductItemsuccess!!!!");
            this.getProductList1();
          }
        });
    },
  },
};
</script>

<style scoped>
.w {
  width: 800px;
  margin: 0 auto;
}

/* 查找模块 */
.com-head {
  position: relative;
  height: 40px;
  margin: 10px 0 10px;
}
.com-search {
  position: absolute;
  right: 10px;
  width: 155px;
  height: 30px;
  margin-top: 5px;
}
.btn-search {
  position: absolute;
  right: 0;
  width: 50px;
  height: 30px;
  text-align: center;
  line-height: 30px;
  font-size: 14px;
  font-weight: 700;
  color: #eee;
  border: 1px solid #e54346;
  border-radius: 5px;
  background-color: #e54346;
  cursor: pointer;
}
.btnall {
  float: left;
  padding: 0 15px;
  text-align: center;
  line-height: 30px;
  font-size: 14px;
  font-weight: 700;
  color: #eee;
  border: 1px solid #e54346;
  border-radius: 5px;
  background-color: #e54346;
  cursor: pointer;
  margin-top: 5px;
}
.com-head input {
  position: absolute;
  width: 100px;
  height: 30px;
  color: #c4baba;
  border: 1px solid #e54346;
  border-radius: 3px;
}

/* 属性模块 */
.com-property {
  height: 25px;
  /* border-top: 1px solid #ccc; */
  border-bottom: 1px solid #ccc;
  background-color: #f3f3f3;
}
.com-property li{
  float: left;
  line-height: 25px;
}
.com-property .c-goods {
  margin: 0 163px 0 60px;
}
.com-property .c-id {
  margin:0px 18px 0px 21px;
}
.com-property .c-price{
    margin: 0px 4px 0px 77px;
}
.com-property .c-brand {
  margin: 0px 5px 0px 74px;
}
.com-property .c-pArea {
  margin: 0 97px 0 96px;
}

/* 商品详细内容模块 */
.com-content {
  /* height: 135px;
  margin: 8px 0;
  border: 1px solid #fee;
  background-color: #fff8f1; */
  overflow: hidden;
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

/* 添加删除模块 */
.add_del {
  position: relative;
  height: 45px;
  margin-top: 20px;
  margin-bottom: 20px;
  border: 1px solid #eee;
}
.add,
.del {
  position: absolute;
  width: 90px;
  /* height: 50px; */
  text-align: center;
  line-height: 45px;
  font-size: 15px;
  font-weight: 700;
  color: #eee;
  border: 1px solid #e54346;
  background-color: #e54346;
  cursor: pointer;
}
.add_del .add {
  right: 110px;
}
.add_del .del {
  right: 0px;
}
</style>
// http://localhost:8080/adminindex/Commodity
// http://localhost:8080/login
// http://localhost:8080/usershopcar