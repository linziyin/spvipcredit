<template>
  <div class="box">
    <h5>
      <span>订单号：{{ showItem.oid }}</span>
      <span class="time">时间：{{ showItem.otime }}</span>
      <span class="del"
        ><a href="javascript:;" @click="btnClick(showItem.oid)"
          >删除</a
        ></span
      >
    </h5>
    <query-item
      v-for="(item, index) in showItem.dataInfo"
      :key="index"
      :item-info="item"
    ></query-item>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import QueryItem from "./queryitem";

export default {
  name: "querybox",
  props: {
    showItem: Object,
    default() {
      return {};
    },
  },
  data() {
    return {
      User:{},
      Orderpj:[],
      ujifen:0,
      pjifen:0,
      userNewCredit:0,
      orderuser:''
    };
  },
  components: {
    QueryItem,
  },
  computed: {
    ...mapGetters(["orderuid"], ["chaxun"]),
  },
  methods: {
    btnClick(oid){ 
      // console.log(this.$store.state.chaxun)
      if(this.$store.state.chaxun==1){
        Promise.all([
          this.GetOrderid(oid),
          this.GetUserByUId(this.orderuid)
        ]).then((res)=>{
          console.log(res)
          this.userNewCredit = res[0] + res[1];
          console.log(this.userNewCredit);
          this.changeucredit(this.userNewCredit, this.orderuid);
          this.deleteOrder(oid)
          // this.ShowOrder1(this.orderuid);
        })
      }
      if(this.$store.state.chaxun==2){
        this.GetOrderid2(oid).then(res=>{
          console.log(res)
          this.orderuser=res 
          Promise.all([
          this.GetOrderid(oid),
          this.GetUserByUId(this.orderuser)
        ]).then((res)=>{
          console.log(res)
          console.log(res[0]+res[1])
          this.userNewCredit = res[0] + res[1];
          console.log(this.userNewCredit);
          this.changeucredit(this.userNewCredit, this.orderuser);
          this.deleteOrder(oid)
          // this.ShowOrder2(oid);
        })
        })
        
       
      }
    },
    deleteOrder(oid) {
      
      // var thisVue=this;
      this.$http
        .get("https://localhost:44339/api/Users/DeleteOrder/?orderid=" + oid)
        .then((res) => {
          
          if (res.data > 0) {
            console.log("deleteordersuccess!!!!");

             this.deleteOrderItemAll(oid);

            console.log(this.$store.state.chaxun);
            if (this.$store.state.chaxun == 1) {
              this.ShowOrder1(this.orderuid);
             
            }
            if (this.$store.state.chaxun == 2) {
              this.ShowOrder2(oid);
            }
          }
        });
    },
    
    deleteOrderItemAll(oid) {
      // var thisVue=this;
      this.$http
        .get(
          "https://localhost:44339/api/Users/DeleteOrderItemAll/?orderid=" + oid
        )
        .then((res) => {
          // console.log(res.data);
          if (res.data > 0) {
            console.log("deleteorderItemsuccess!!!!");
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
    GetOrderid2(oid) {
      return new Promise((resolve,reject)=>{
        var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Orders/GetOrderByOid/?oid=" + oid)
        .then((res) => {
          console.log(res.data);
          console.log(res.data.length);
          thisVue.Orderpj=res.data;
         console.log(this.Orderpj[0].user_id)
        //  this.orderuser=this.Orderpj[0].user_id
        //  this.GetUserByUId(this.orderuser)
          resolve(this.Orderpj[0].user_id)
        });
      })
      
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
    GetOrderid(oid) {
      return new Promise((resolve,reject)=>{
        var thisVue = this;
      this.$http
        .get("https://localhost:44339/api/Orders/GetOrderByOid/?oid=" + oid)
        .then((res) => {
          console.log(res.data);
          console.log(res.data.length);
          thisVue.Orderpj=res.data;
          thisVue.pjifen=0;
          for(var index in this.Orderpj){
            console.log(this.Orderpj[index].pnewCredit)
            console.log(this.Orderpj[index].user_id)
            this.pjifen=this.pjifen+this.Orderpj[index].pnewCredit
            
          }
          console.log(this.pjifen)
          resolve(this.pjifen)
        });
      })
      
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
.box {
  margin: 10px 0;
  border: 1px solid #aaa;
  overflow: hidden;
  border-radius: 10px;
}
h5 {
  display: inline-block;
  width: 100%;
  height: 30px;
  line-height: 30px;
  background-color: #e9e9e9;
}
h5 .time {
  font-weight: 14px;
  margin-left: 20px;
  color: rgb(170, 170, 170);
}
h5 .del {
  float: right;
  margin-right: 20px;
}
</style>