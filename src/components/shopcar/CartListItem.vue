<template>
  <div class="cart-item " :class="{checkcartitem:this.itemInfo.pchecked==='true'}">
    <check-button
      class="check-button"
      :is-checked="itemInfo.pchecked"

      @click.native="checkClick"
    ></check-button>
    <div class="p-goods">
      <div class="p-img">
        <!-- <img src="../../upload/p1.jpg" alt="" /> -->
        <img :src="require('@/'+itemInfo.pimgurl+'')" alt="" />
        <!-- <img :src="itemInfo.pimgurl" alt="" /> -->
 
      </div>
      <div class="p-msg">
        {{ itemInfo.pname }}
        <!-- 好东西 -->
      </div>
    </div>
    <div class="p-price">
      {{ -itemInfo.pcredit }}
      <!-- 很多钱 -->
    </div>
    <div class="p-num">
      <div class="quantity-form">
        <a href="javascript:;" class="decrement" @click="downclick">-</a>
        <input type="text" class="itxt" v-model.number="itemInfo.pcount"/>
        <a href="javascript:;" class="increment" @click="upclick">+</a>
      </div>
    </div>
    <div class="p-sum">{{pSum}}</div>
    <div class="p-action"><a href="javascript:;" @click="btnclick">详情</a></div>
    <div  :class="{ pdes: this.choose }" class="detail">
        <h2>详细信息</h2>
        <span>品牌:{{itemInfo.pbrand}}</span>
        <span>生产地区：{{itemInfo.parea}}</span>
        <span>产品分类：{{itemInfo.psort}}</span>
    </div>
  </div>

</template>

<script>
import CheckButton from "../checkButton/CheckButton";
import {mapActions} from 'vuex'

export default {
  name: "CartListItem",
  components: {
    CheckButton
  },
  props: {
    itemInfo: {
      type: Object,
      default() {
        return {};
      },
    },
    
  },
  data() {
    return {
      checked:false,
      choose : true
    }
  },
  computed:{
    pSum(){
      return this.itemInfo.pnewCredit=-this.itemInfo.pcredit * this.itemInfo.pcount

    }
  },
  methods: {  
    ...mapActions(['usechecked']),

    checkClick() {
      
      // this.getProductById()
      // console.log(this.itemInfo.pid);
      // this.iid=this.itemInfo.pid;
      // console.log(this.iid);
      // console.log(this.itemInfo);
      // // const profuct=this.itemInfo;
      // // this.$store.commit('addchecked',profuct)
      this.$store.dispatch('usechecked',this.itemInfo.pid)
      // console.log(this.itemInfo);
      console.log(this.itemInfo.pchecked)
      // this.itemInfo.pchecked = !this.itemInfo.pchecked;
      // this.checked=!this.checked;

      // console.log(this.itemInfo.checked)


    },
    // getProductById(){
    //   var thisVue=this;
    //   this.$http.get("https://localhost:44399/api/Products/GetProductById?pid="+this.productlist.pid+"").then(res=>{
    //     thisVue.cart=res.data;
    //     console.log(thisVue.cart)
    //   })
    // },
    btnclick(){
      this.choose=!this.choose;
    },
    downclick(){
      if(this.itemInfo.pcount===1){

      }else{
         this.itemInfo.pcount--;
      }
    },
    upclick(){
      this.itemInfo.pcount++;
    }
  },
};
</script>

<style scoped>
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
.check-button {
  margin-left: 20px;
}

.cart-item {
  /* height: 160px; */
  border-style: solid;
  border-width: 2px 1px 1px;
  border-color: #aaa #f1f1f1 #f1f1f1;
  background: #fff;
  padding-top: 14px;
  margin: 15px 0;
  overflow: hidden;
}

.checkcartitem {
  background: #fff4e8;
}

.p-checkbox {
  width: 50px;
}

.p-goods {
  margin-top: 8px;
  width: 565px;
}

.p-img {
  float: left;
  border: 1px solid #ccc;
  /* padding: 5px; */
  margin-left: 100px;
}

.p-msg {
  float: left;
  width: 210px;
  margin: 0 10px;
}

.p-price {
  width: 110px;
  margin-left: 30px;
}

.quantity-form {
  width: 80px;
  height: 22px;
}

.p-num {
  width: 170px;
}

.decrement,
.increment {
  float: left;
  border: 1px solid #cacbcb;
  height: 18px;
  line-height: 18px;
  padding: 1px 0;
  width: 16px;
  text-align: center;
  color: #666;
  margin: 0;
  background: #fff;
  margin-left: -1px;
}

.itxt {
  float: left;
  border: 1px solid #cacbcb;
  width: 32px;
  height: 18px;
  line-height: 18px;
  text-align: center;
  padding: 1px;
  margin: 0;
  margin-left: -1px;
  font-size: 12px;
  font-family: verdana;
  color: #333;
  -webkit-appearance: none;
}

.p-sum {
  font-weight: 700;
  width: 145px;
}

.pdes {
  display: none;
}

.detail {
    width: 1065px;
    border-top: 1px solid #aaa;
    margin-top: 10px; 
    margin-left: 137px;
}
.detail h2 {
    margin-top: 5px;
    margin-left: 10px;
}
.detail span {
    display: inline-block;
    margin-top: 10px;
    margin-left: 10px;
    width: 340px;
    margin-bottom: 20px;
}
</style>