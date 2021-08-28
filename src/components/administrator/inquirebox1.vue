<template>
  <div class="inquire">
    <div class="title">查询消费记录</div>
    <div class="query">
      <form action="">
        <label for="">用户账号：</label>
        <input type="text" class="inp" v-model.lazy="uid" />
      </form>
      <div class="btn" @click="btnClick1(uid)">查询</div>
    </div>
    <div class="query">
      <form action="">
        <label for="">订单号：</label>
        <input type="text" class="inp" v-model.lazy="oid" />
      </form>
      <div class="btn" @click="btnClick2(oid)">查询</div>
    </div>

  </div>
</template>

<script>

import { mapActions, mapGetters } from "vuex";

export default {
  name: "inquirebox1",
  data() {
    return {
      uid: "",
      oid: "",
      showList: [],
      newData:[]
    };
  },
 computed:{
   ...mapGetters(['getpList'])
 },
  methods: {
    // ...mapGetters(["getpList"]),
    ...mapActions(["showpid"]), 
    //  refreshPage(){
    //   this.$router.replace({
    //     path:'/refresh'
    //   })
    // },

    btnClick1(uid) {
      this.ShowOrder1(uid);
      this.$store.commit('changechaxun',1);
      console.log(this.$store.state.chaxun)
      // this.refreshPage();
      // console.log('刷新了1')

    },
  
    btnClick2(oid){
      this.ShowOrder2(oid);
      this.$store.commit('changechaxun',2);
      console.log(this.$store.state.chaxun)
    },
    ShowOrder1(uid) {
      this.$store.commit('getorderuid',uid);
      console.log(this.$store.state.orderuid)
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
          console.log(this.showList)
          
          this.$store.commit("adddeleteList",this.showList)
          console.log(this.$store.state.deleteList)
          
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
  },
};
</script>

<style scoped>
.inquire {
  border-top: 1px solid #c81623;
  margin-top: 10px;
}
.inquire .title {
  font-size: 18px;
  margin: 10px 5px;
}
.query {
  margin-top: 20px;
  overflow: hidden;
  padding: 10px 122px;
  border: 1px solid #aaa;
  border-radius: 10px;
}
.query form {
  float: left;
}
.query label {
  display: inline-block;
  width: 88px;
  text-align: right;
}
.query .inp {
  width: 242px;
  height: 37px;
  border: 1px solid #ccc;
}
.btn {
  margin-left: 20px;
  cursor: pointer;
  float: left;
  width: 100px;
  height: 34px;
  background-color: #c81623;
  font-size: 14px;
  color: #fff;
  text-align: center;
  line-height: 34px;
}
</style>