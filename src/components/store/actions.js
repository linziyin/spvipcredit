export default {
    addCart(context, payload) {
        return new Promise((resolve, reject) => {
            let product = context.state.cartList.find(item => item.iid === payload.iid)
            if (product) {
                // product.count += 1
                context.commit('addCounter', product)
                resolve("数量+1")
            }
            else {
                payload.count = 1
                // context.state.cartList.push(payload)
                context.commit('addToCart', payload)
                resolve("加新的商品")
            }
        })
    },
    usechecked(context, payload) {
        return new Promise((reslove, reject) => {
            let product = context.state.cartList.find(item => item.pid === payload)
            if (product.pchecked == 'true') {
                context.commit('subchecked', product)
            }
            else {
                context.commit('addchecked', product)

            }
        })
    },
    usechecked1(context, payload) {
        return new Promise((reslove, reject) => {
            let product = context.state.cartList1.find(item => item.pid === payload)
            if (product.pchecked == 'true') {
                context.commit('subchecked', product)
            }
            else {
                context.commit('addchecked', product)

            }
        })
    },
    checklogin(context, payload) {
        return new Promise((reslove, reject) => {
            // let user = context.state.userList.find(item => {
            //     item.uid === payload.message1
            // })
            // console.log(payload.message1)
            // console.log(payload.message2)
            let user = context.state.userList.find(function (item) {
                if (item.uid === payload.message1 && item.pwd === payload.message2)
                    return true;
            })
            if (user) {
                context.commit('storelogin', user)
                // console.log(context.state.loginuid)
                // console.log(context.state.uidcredit)
                // console.log(user.type)
                reslove(user.type);
            }
            else {
                reslove("输入错误，请重新输入")
            }


        })
    },
    achanguidcredit(context, payload) {
        return new Promise((resolve, reject) => {
            context.commit('mchanguidcredit', payload)
            resolve(context.state.uidcredit)
        })
    },
    showpid(context, payload) {
        return new Promise((reslove, reject) => {
            let product = context.state.cartList.find(function (item) {
                if (item.pid === payload)
                    return true;
            })
            if (product) {
                // context.commit('findpid', product)

                reslove(product)
            }
            else {
                reslove("未找到")
            }
        })
    },
    deleteorder(context, payload) {
        return new Promise((reslove, reject) => {
            let dList = context.state.deleteList.filter(function (item) {
                return (item.oid==payload)
            })
            if (dList) {
                console.log(dList)
            }
        })
    },
 
}