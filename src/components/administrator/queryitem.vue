<template>
  <div class="cart-item">
    <div class="p-goods">
      <div class="p-img">
        <img :src="require('@/'+itemInfo.pimgurl+'')" alt="" />
        <!-- <img :src="itemInfo.pimgurl" alt="" /> -->
      </div>
      <div class="p-msg">
        {{ itemInfo.pname }}
      </div>
    </div>
    <div class="p-num">
      {{ itemInfo.count }}
    </div>
    <div class="p-sum">{{ itemInfo.pnewCredit>0?itemInfo.pnewCredit:-itemInfo.pnewCredit }}</div>
    <div>
      <a href="javascript:;" @click="btnClick(itemInfo.pid, itemInfo.oid)"
        >删除</a
      >
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "query",
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
      ujifen: 0,
      userNewCredit: 0,
    };
  },
  computed: {
    ...mapGetters(["orderuid"], ["chaxun"]),
  },
  methods: {
    btnClick(pid, oid) {
      // if(this.$store.state.chaxun==1){
      //   console.log(this.itemInfo.user_id)
      //   this.GetUserByUId(this.itemInfo.user_id).then(res=>{
      //     console.log(res+this.itemInfo.pnewCredit)
      //     this.userNewCredit=res+this.itemInfo.pnewCredit
      //     this.changeucredit(this.userNewCredit,this.itemInfo.user_id)
      //     this.deleteOrderItem(pid,oid)
      //     this.ShowOrder1(this.orderuid);

      //   })
      // }
      // if(this.$store.state.chaxun==2){
      //   console.log(this.itemInfo.user_id)
      //   this.GetUserByUId(this.itemInfo.user_id).then(res=>{
      //     console.log(res+this.itemInfo.pnewCredit)
      //     this.userNewCredit=res+this.itemInfo.pnewCredit
      //     this.changeucredit(this.userNewCredit,this.itemInfo.user_id)
      //     this.deleteOrderItem(pid,oid)
      //     this.ShowOrder2(oid)

      //   })
      // }
      console.log(this.itemInfo.user_id);
      this.GetUserByUId(this.itemInfo.user_id).then((res) => {
        console.log(res + this.itemInfo.pnewCredit);
        this.userNewCredit = res + this.itemInfo.pnewCredit;
        this.changeucredit(this.userNewCredit, this.itemInfo.user_id);
        this.deleteOrderItem(pid, oid);
      });
      // if (this.$store.state.chaxun == 1) {
      //   this.ShowOrder1(this.orderuid);
      // }
      // if (this.$store.state.chaxun == 2) {
      //   this.ShowOrder2(oid);
      // }
    },
    deleteOrderItem(pid, oid) {
      // var thisVue=this;
      this.$http
        .get(
          "https://localhost:44339/api/Users/DeleteOrderItem/?productid=" +
            pid +
            "&orderid=" +
            oid
        )
        .then((res) => {
          // console.log(res.data);
          if (res.data > 0) {
            console.log("deleteorderItemsuccess!!!!");
            console.log(this.$store.state.chaxun)
            if(this.$store.state.chaxun==1){
              this.ShowOrder1(this.orderuid);
            }
            if(this.$store.state.chaxun==2){
              this.ShowOrder2(oid)
            }
          }
        });
    },
    ShowOrder1(uid) {
      // this.$store.commit('getorderuid',uid);
      // console.log(this.$store.state.orderuid)
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
          console.log(this.showList);

          // this.$store.commit("adddeleteList",this.showList)
          // console.log(this.$store.state.deleteList)

          console.log(Data);
          // thisVue.newData=Data;
          this.$store.commit("addpList", Data);
          console.log(this.$store.state.pList);
        });
    },
    ShowOrder2(oid) {
      var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Orders/GetOrderByOid/?oid=" + oid)
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
.cart-item > div {
  float: left;
}
.cart-item {
  overflow: hidden;
  border-style: solid;
  border-width: 2px 1px 1px;
  border-color: #aaa #f1f1f1 #f1f1f1;
  padding-top: 10px;
  padding-left: 5px;
  padding-bottom: 10px;
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
  padding: 5px;
}

.p-msg {
  float: left;
  width: 210px;
  margin: 0 10px;
}

.p-num {
  width: 153px;
  text-align: center;
}

.p-sum {
  font-weight: 700;
  width: 145px;
  text-align: center;
}

.p-price {
  width: 110px;
  margin-left: 30px;
}
</style>