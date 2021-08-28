<template>
<div class="bg" :style="bg">
    <div class="welcome w">!欢迎进入超市会员积分管理系统!</div>
  <div class="registerarea w">
    <h3>用户登录</h3>
    <div class="reg_form">
      <form action="">
        <ul>
          <li>
            <label for="">账号：</label>
            <input type="text" class="inp" v-model.lazy="message.message1" />
          </li>
          <li>
            <label for="">登录密码：</label>
            <input type="password" class="inp" v-model.lazy="message.message2" />
          </li>        
        </ul>
      </form>
      <button class="btn" @click="btnClick">登录</button>
    </div>
    <toast :message="showmessage" :is-show="show"></toast>
  </div>
    <!-- {{islogin}} -->


  </div>
</template>

<script>
import {mapGetters,mapActions} from 'vuex'
import toast from '../toast/Toast'
export default {
  name: "UserLogin",
  components:{
    toast
  },
  data() {
    return {
      message:{message1:'',message2:''},
      showmessage:'',
      show:false,
      bg: {
        backgroundImage: "url(" + require("../../upload/bg-img1.jpg") + ")",
        backgroundRepeat: "no-repeat",
        backgroundSize: "100% 100%",
      },
    }
  },
  // computed:{
  //   ...mapGetters(['userList']),
  //   islogin(){
  //     return this.userList.filter(item=>{
  //       item.uid===this.message1 && item.pwd===this.message2
  //     }).length
  //   },
  // },
  methods:{
    ...mapGetters(['userList']),
    ...mapActions(['checklogin']),
    showtoast(){
          this.show=true;
          setTimeout(() => {
            this.show=false;
            this.showmessage='';
          }, 2000);
    },
    btnClick(){
      // console.log("login")
      // console.log(this.message.message1);
      // console.log(this.message.message2);
      // if(this.islogin()!=0){
      //   console.log("找到了")
      // }
      // else{
      //   console.log("没有改用户")
      // }
      // this.$store.dispatch('checklogin',this.message);
      this.checklogin(this.message).then(res=>{
        // console.log(res)
        if(res==2){
          this.showmessage="管理员登录成功！"
          this.show=true;
          setTimeout(() => {
            this.show=false;
            this.showmessage=''; 
            this.$router.push('/adminindex')
          }, 2000);    
        }
        else if(res==1) {
          this.showmessage="用户"+this.message.message1+"登录成功！"
          this.show=true;
          setTimeout(() => {
            this.show=false;
            this.showmessage=''; 
            this.$router.push('/usershopcar')
          }, 2000);
        }
        else{
          this.message.message1='';
          this.message.message2='';
          this.showmessage="输入错误，请重新输入";
          this.showtoast();
        }
      })
    }
  }
};
</script>

<style scoped>
.bg{
  height: 865px;
  overflow: hidden;
}
.bg .welcome{
  margin-top: 30px;
  text-align: center;
  font-size: 55px;
  font-family: STHupo;
  /* font-weight: 700; */
  color: #3cade9;
}
.w {
  width: 900px;
  margin: 0 auto;
}
.registerarea {
  width: 371px;
  height: 295px;
  margin-top: 164px;
  background-color: #fff;
  border: 9px solid #f6d04b;
  border-radius: 25px;
  overflow: hidden;
}
.registerarea h3 {
  height: 42px;
  line-height: 42px;
  padding: 0 10px;
  font-weight: 400;
  font-size: 18px;
  color: #fff;
  border-bottom: 1px solid #ccc;
  background-color: #c81623;
}
.reg_form {
  width: 600px;
  margin: 50px auto 0;
}
.reg_form ul li {
  margin-bottom: 20px;
}
.reg_form ul li label {
  display: inline-block;
  width: 88px;
  text-align: right;
}
.reg_form ul li .inp {
  width: 242px;
  height: 37px;
  border: 1px solid #ccc;
}
.btn {
  width: 200px;
  height: 34px;
  background-color: #c81623;
  font-size: 14px;
  color: #fff;
  margin: 30px 0 0 70px;
}
</style>