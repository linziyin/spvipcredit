<template>
    <div class="check-button" :class="{check:isChecked=='true'}">
        <img src="~assets/img/checkbutton/tick.svg" alt="" >
    </div>
</template>

<script>
export default {
   name: "CheckButton",
   props:{
       isChecked:{
           type:String,
            default:''
       }
   }
}
</script>

<style scoped>
.check-button{
    width: 22px;
    height: 22px;
    border-radius: 50%;
    border: 2px solid #aaa;
    margin-left: 10px;
    margin-top: 10px;
}
.check{
    border-color: red;
    background-color: red;
}
img{
    width: 100%;
    height: 100%;
    margin-bottom: 3px;
}

</style>
