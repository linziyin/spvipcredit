<template>
  <div class="box">
    <h5>
        <span>订单号：{{ orderItem.oid }}</span>
        <span class="time">时间：{{orderItem.otime}}</span>
    </h5>
    <calendar-item v-for="(item,index) in orderItem.dataInfo" :key="index" :item-info="item"></calendar-item>
    <!-- {{orderList[0].orderitem}} -->
    <!-- {{orderItem.orderitem}} -->
  </div>
</template>

<script>
import CalendarItem from './calendaritem'

export default {
  name: "calendarbox",
  props:{
    orderItem:{
      type:Object,
      default(){
        return {}
      }
    }
  },
  components : {
     CalendarItem
  }
};
</script>

<style scoped>
.box {
  width: 700px;
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
    color:rgb(170, 170, 170);
}

</style>