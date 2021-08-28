<template>
  <div
    class="c-content"
    :class="{ checkcartitem: this.itemInfo.pchecked === 'true' }"
  >
    <check-button
      class="check-button"
      :is-checked="itemInfo.pchecked"
      @click.native="checkClick"
    ></check-button>

    <div class="cc-goods">
      <!-- <img src="#" alt="" /> -->
      <img :src="require('@/' + itemInfo.pimgurl + '')" alt="" />

      <div class="c-msg">
        {{ itemInfo.pname }}
      </div>
    </div>
    <div class="cc-id">{{ itemInfo.pid }}</div>
    <div class="cc-price">
      {{ itemInfo.pcredit > 0 ? itemInfo.pcredit : -itemInfo.pcredit }}
    </div>
    <div class="cc-brand">{{ itemInfo.pbrand }}</div>
    <div class="cc-pArea">{{ itemInfo.parea }}</div>
    <div class="cc-category">{{ itemInfo.psort }}</div>
  </div>
</template>

<script>
import CheckButton from "../checkButton/CheckButton";
import { mapActions } from "vuex";
export default {
  name: "commodityitem",
  components: {
    CheckButton,
  },
  props: {
    itemInfo: {
      type: Object,
      default() {
        return {};
      },
    },
  },
  methods: {
    ...mapActions(["usechecked1"]),
    checkClick() {
      this.$store.dispatch("usechecked1", this.itemInfo.pid);
      console.log(this.itemInfo.pid);
      console.log(this.itemInfo.pchecked);
    },
  },
};
</script>

<style scoped>
.checkcartitem {
  background: #fff4e8;
}

.check-button {
  width: 22px;
  height: 22px;
  line-height: 20px;
  margin-right: 5px;
  margin-top: 0px;
}

.c-content {
  width: 100%;
  height: 100px;
  border-style: solid;
  border-width: 2px 1px 1px;
  border-color: #aaa #f1f1f1 #f1f1f1;
  padding-top: 14px;
  margin: 15px 0;
}
.c-content > div {
  float: left;
}
.cc-goods {
  width: 208px;
  height: 90px;
  margin-left: 10px;
  margin-right: 10px;
}
.cc-goods img {
  width: 80px;
  height: 80px;
  /* padding: 5px; */
  border: 1px solid #ccc;
}
.c-msg {
  float: right;
  width: 112px;
  margin-left: 10px;
}

.cc-price {
  width: 40px;
  text-align: center;
  margin-left: 83px;
}
.cc-brand {
  width: 40px;
  text-align: center;
  margin-left: 63px;
}
.cc-pArea {
  width: 49px;
  text-align: center;
  margin-left: 86px;
}
.cc-category {
  width: 40px;
  text-align: center;
  margin-left: 84px;
}
</style>