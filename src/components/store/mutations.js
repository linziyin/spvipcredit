export default {
    addCounter(state, payload) {
        payload.count++
    },
    addToCart(state, payload) {
        // payload.forEach(item => item.checked = false)
        state.cartList = payload
    },
    addToCart1(state, payload) {
        // payload.forEach(item => item.checked = false)
        state.cartList1 = payload
    },
    addUserMessage(state, payload) {
        state.userList = payload
    },
    addchecked(state, payload) {
        // let product = state.cartList.find(item => item.pid === payload)
        payload.pchecked = 'true';
    },
    subchecked(state, payload) {
        payload.pchecked = 'false';

    },
    storelogin(state, payload) {
        state.loginuid = payload.uid;
        state.uidcredit = payload.ucredit;
    },
    mchanguidcredit(state, payload) {
        state.uidcredit = state.uidcredit - payload;
    },
    addToOrder(state, payload) {
        state.orderList.push(payload);
    },
    addpList(state, payload) {
        state.pList = payload;
    },
    adddeleteList(state, payload) {
        state.deleteList=payload
    },
    getorderuid(state, payload) {
        state.orderuid=payload
    },
    changechaxun(state, payload) {
        state.chaxun=payload
    }
}