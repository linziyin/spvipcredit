<template>
  <div class="w">
    <div class="shortcut">
      <div class="fl">
        <ul>
          <li>
            欢迎您！ {{ this.$store.state.loginuid }} 您的积分还剩下{{
              this.$store.state.uidcredit
            }}
          </li>
        </ul>
      </div>
      <div class="fr">
        <ul>
          <li><a href="javascript:;" @click="aClick">查看消费记录</a></li>
        </ul>
      </div>
    </div>
    <div class="car-header">
      <div class="car-logo">
        <b>积分兑换</b>
      </div>
    </div>
    <!-- <div class="c-container"> -->
    <div class="cart-filter-bar">
      <em>全部商品</em>
    </div>

    <!-- 购物车主要核心区域 -->
    <!-- <div class="cart-warp"> -->
    <!-- 头部模块 -->
    <div class="cart-thead">
      <div class="t-goods">商品</div>
      <div class="t-price">积分</div>
      <div class="t-num">数量</div>
      <div class="t-sum">小计</div>
      <div class="t-action">操作</div>
    </div>
    <!-- 商品详细模块 -->
    <cart-list></cart-list>

    <cart-float-bar />
    <back-top @click.native="backClick" v-show="isShowBackTop"></back-top>
    <!-- <ul>
      <li>11</li>
      <li>21</li>
      <li>31</li>
      <li>41</li>
      <li>51</li>
      <li>61</li>
      <li>71</li>
      <li>81</li>
      <li>91</li>
      <li>101</li>
      <li>111</li>
      <li>121</li>
      <li>131</li>
      <li>141</li>
      <li>151</li>
      <li>161</li>
      <li>171</li>
      <li>181</li>
      <li>191</li>
      <li>201</li>
      <li>211</li>
      <li>221</li>
      <li>231</li>
      <li>241</li>
      <li>251</li>
      <li>261</li>
      <li>271</li>
      <li>281</li>
      <li>291</li>
      <li>301</li>
      <li>311</li>
      <li>321</li>
      <li>331</li>
      <li>341</li>
      <li>351</li>
      <li>361</li>
      <li>371</li>
      <li>381</li>
      <li>391</li>
      <li>401</li>
      <li>411</li>
      <li>421</li>
      <li>431</li>
      <li>441</li>
      <li>451</li>
      <li>461</li>
      <li>471</li>
      <li>481</li>
      <li>491</li>
      <li>501</li>
    </ul> -->
  </div>
</template>

<script>
import CartList from "./CartList";
import CartFloatBar from "./CartFloatBar";

import BackTop from "../backtop/BackTop";
import CheckButton from "../checkButton/CheckButton";

// import { mapGetters} from 'vuex'

export default {
  name: "shopcar",
  components: {
    CartList,
    CartFloatBar,
    BackTop,
    CheckButton,
  },
  data() {
    return {
      isShowBackTop: true,
      // getProducts:[]
    };
  },

  mounted() {
    // console.log(window.pageYOffset);
    // console.log(window.scrollY);
    // window.addEventListener("scroll", this.listenShowBackTop, true);
    // this.getProductList();
  },
  // computed:{
  //      ...mapGetters(['cartList'])
  //     //  this.getProductList=this.cartList
  // },
  methods: {
    backClick() {
      window.scrollTo(0, 0, 500);
    },
    // listenShowBackTop() {
    //   console.log(window.pageYOffset);
    //   console.log(window.scrollY);
    //   this.isShowBackTop = window.scrollY > 1000;
    // },
    aClick() {
      this.$router.push("/calendar");
      this.ShowOrder1(this.$store.state.loginuid)
    },
     ShowOrder1(uid) {
      var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Orders/GetOrderByUid/?uid=" + uid)
        .then((res) => {
          console.log(res.data);
          console.log(res.data.length);
          thisVue.showList = res.data;

          let tempArr = [];
          let Data = [];
          for (let i = 0; i < thisVue.showList.length; i++) {
            if (tempArr.indexOf(thisVue.showList[i].oid) === -1) {
              Data.push({
                oid: thisVue.showList[i].oid,
                otime: thisVue.showList[i].otime,
                dataInfo: [thisVue.showList[i]],
              });
              tempArr.push(thisVue.showList[i].oid);
            } else {
              for (let j = 0; j < Data.length; j++) {
                if (Data[j].oid == thisVue.showList[i].oid) {
                  Data[j].dataInfo.push(thisVue.showList[i]);
                  break;
                }
              }
            }
          }
          console.log(Data);
          // thisVue.newData=Data;
          this.$store.commit("addpList", Data);
          console.log(this.$store.state.pList);
          
        });
    },

    // getProductList(){
    //   var thisVue=this;
    //   this.$http.get('https://localhost:44339/api/Products/GetProducts').then(res=>{
    //     thisVue.getProducts=res.data;
    //   })
    // },
  },
};
</script>

<style scoped>
li {
  list-style: none;
}
.fl {
  float: left;
  margin-left: 8px;
}

.fr {
  float: right;
  margin-right: 8px;
}
/*版心*/

.w {
  width: 1200px;
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

.cart-thead > div,
.cart-item > div {
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
  margin-left: 140px;
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
  width: 100px;
  text-align: right;
}

.t-action {
  width: 130px;
  text-align: right;
}
</style>