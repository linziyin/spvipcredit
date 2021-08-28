<template>
  <div class="form-area w">
    <h2>
      添加商品
      <a href="#" @click="backClick">返回</a>
    </h2>
    <!-- class="form-area" -->
    <div class="form-content">
      <form action="" methods="post">
        <ul class="form-inp">
          <li>
            <label for="">货号：</label>
            <input type="text" v-model.lazy="pid" />
          </li>
          <li>
            <label for="">积分：</label>
            <input type="text" v-model.lazy="pcredit" />
          </li>
          <li>
            <label for="">品牌：</label>
            <input type="text" v-model.lazy="pbrand" />
          </li>
          <li>
            <label for="">类别：</label>
            <input type="text" v-model.lazy="psort" />
          </li>
          <li>
            <label for="">产地：</label>
            <input
              type="text"
              name=""
              id=""
              cols="19"
              rows="3"
              v-model.lazy="parea"
            />
          </li>
          <li>
            <label for="">商品简介：</label>
            <textarea
              name=""
              id=""
              cols="19"
              rows="3"
              v-model.lazy="pname"
            ></textarea>
          </li>
        </ul>
        <div class="up-img">
          <!-- <div class="pre-img"><a href="javascript:;">图片名称</a></div> -->
          <input
            type="file"
            id="profile_pic"
            name="profile_pic"
            accept=".png, .jpg, .jpeg"
          />
          <!-- <button>上传图片</button> -->
        </div>
        <div class="ensure" @click="btnClick">确认</div>
      <toast :message="showmessage" :is-show="show"></toast>

      </form>
    </div>
  </div>
</template>

<script>
import toast from '../toast/Toast'

export default {
  name: "comAddGoods",
  components:{
    toast
  },
  data() {
    return {
      pid: "",
      pname: "",
      pimgurl: "",
      pcredit: "",
      pbrand: "",
      parea: "",
      psort: "",
      showmessage:"",
      show:false
    };
  },
  // computed: {

  // },
  methods: {
    btnClick() {
      //confirm( document.getElementById("profile_pic").value);
      this.addGoods();
      console.log("123");
    },
    addGoods() {
      // var thisVue=this;
      this.$http
        .get(
          "https://localhost:44339/api/Products/AddGoods/?pid=" +
            this.pid +
            "&pname=" +
            this.pname +
            "&pimgurl=" +
            document.getElementById("profile_pic").value +
            // "C:\\Users\\LZY13\\Desktop\\spmarket\\src\\upload\\erweima.png"+
            "&pcredit=" +
            this.pcredit +
            "&pbrand=" +
            this.pbrand +
            "&parea=" +
            this.parea +
            "&psort=" +
            this.psort +
            ""
        )
        .then((res) => {
          if (res.data > 0) {
            console.log("success!!!!");
            this.showmessage = "添加商品成功";
            this.show = true;
            setTimeout(() => {
              this.show = false;
              this.showmessage = "";
            }, 2000);
          }
        });
    },
    backClick() {
      this.$router.back(-1);
    },
  },
};
</script>

<style scoped>
.w {
  width: 800px;
  margin: 0 auto;
}
.form-area {
  height: 522px;
  margin: 20px auto;
  border: 2px solid #ccc;
  border-radius: 10px;
  overflow: hidden;
}
.form-area h2 {
  height: 35px;
  line-height: 35px;
  text-indent: 15px;
  border-bottom: 2px solid #ccc;
}
.form-area h2 a {
  float: right;
  font-size: 14px;
  margin-right: 10px;
}
.form-content {
  width: 600px;
  margin: 50px auto 0;
}
.form-inp li {
  margin: 20px 0 10px 120px;
}
.form-inp li label {
  display: inline-block;
  width: 100px;
  text-align: right;
}
/* .form-inp li input {
} */
.up-img {
  position: relative;
  width: 220px;
  height: 30px;
  margin: 0 0 0 160px;
}
.up-img input {
  position: absolute;
  left: 0;
}
.up-img .pre-img {
  position: absolute;
  right: 5px;
}
.ensure {
  margin: 30px 240px 10px;
  width: 120px;
  height: 30px;
  font-size: 14px;
  color: #eee;
  background-color: #c81623;
  text-align: center;
  line-height: 30px;
  cursor: pointer;
}
</style>