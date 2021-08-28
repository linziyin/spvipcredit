import Vue from 'vue'
import VueRouter from 'vue-router'

//懒加载
const login = () => import('components/login/UserLogin')
const usershopcar=()=>import('components/shopcar/ShopCar')
const calendar = () => import('components/expensecalendar/calendar')
const adminindex = () => import('components/administrator/adminindex')

const Calendarpage = () =>import('components/administrator/calendarpage')
const Commodity = () => import('components/administrator/commodity')
const ComAddGoods = () => import('components/administrator/comAddGoods')

// const querybox = () => import('components/administrator/inquirebox2')
const Refresh=()=>import('components/refresh')
Vue.use(VueRouter)

const routes = [
    {
        path: '',
        redirect: '/login'
    },
    {
        path: '/login',
        component: login
    },
    {
        path: '/usershopcar',
        component: usershopcar
    },
    {
        path: '/calendar',
        component: calendar
    },
    // {
    //     path: '/Calendarpage',
    //     component: Calendarpage
    // },

    // {
    //     path: '/Commodity',
    //     component: Commodity
    // },
    {
        path: '/adminindex',
        component: adminindex,
        children: [
            {
                path: '',
                redirect: 'Calendarpage'
            },
            {
                path: 'Calendarpage',
                component: Calendarpage,
                // children: [
                //     {
                //         path: 'querybox',
                //         component:querybox,
                //     }
                // ]
            },
            {
                path: 'Commodity',
                component: Commodity
            },
        ]
    },
    {
        path: '/ComAddGoods',
        component: ComAddGoods
    },
    {
        path: '/refresh',
        component: Refresh
    }

]

const router = new VueRouter({
    routes,
    mode:'history'
})

export default router