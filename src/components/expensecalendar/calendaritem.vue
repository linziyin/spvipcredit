<template>
    <div class="cart-item">
      <div class="p-goods">
        <div class="p-img">
          <img :src="require('@/'+itemInfo.pimgurl+'')" alt="" />
        <!-- <img :src="itemInfo.pimgurl" alt="" /> -->

        </div>
        <div class="p-msg">
          {{itemInfo.pname}}
        </div>
      </div>
      <div class="p-num">
        {{ itemInfo.count }}
      </div>
      <div class="p-sum">{{itemInfo.pnewCredit>0?itemInfo.pnewCredit:-itemInfo.pnewCredit}}</div>
    </div>
</template>

<script>
export default {
    name:'calendaritem',
    data() {
        return {
            counts :1
        }
    },
    props:{
      itemInfo:{
        type:Object,
        default(){
          return {}
        }
      }
    }
}
</script>

<style scoped>
.cart-item > div {
  float: left;
}

.cart-item {
  height: 117px;
  border-style: solid;
  border-width: 2px 1px 1px;
  border-color: #aaa #f1f1f1 #f1f1f1;
  padding-top: 5px;
  padding-left: 5px;
}

.p-checkbox {
  width: 50px;
}

.p-goods {
  margin-top: 8px;
  width: 400px;
}

.p-img {
  float: left;
  border: 1px solid #ccc;
  /* padding: 5px; */
}

.p-msg {
  float: left;
  width: 210px;
  margin: 0 10px;
}

.p-num {
  width: 150px;
  text-align: center;
}

.p-sum {
  font-weight: 700;
  width: 140px;
  text-align: center;
}
</style>