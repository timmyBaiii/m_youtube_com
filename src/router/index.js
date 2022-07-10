import { createRouter, createWebHashHistory } from 'vue-router';
import Layout from '@/layout/index.vue';

const constantRoutes = [
    {
        path: '/',
        component: Layout,
        children: [
            {
                path: '/',
                component: () => import('@/views/home/index.vue'),
                meta: { title: '首頁' },
                name: 'home',
            }
        ]
    },
    {
        path: '/loveMovie',
        redirect: '/loveMovie/index',
        component: Layout,
        children: [
            {
                path: 'index',
                component: () => import('@/views/loveMovie/index.vue'),
                meta: { title: '喜歡影片' },
                name: 'loveMovie'
            }
        ]
    }
];

// permission router
export const asyncRoutes = [
];

const createCustomRouter = () => createRouter({
    history: createWebHashHistory(),
    scrollBehavior: () => ({ top: 0 }),
    routes: constantRoutes
});

const router = createCustomRouter();

export const resetRouter = () => {
    const newRouter = createCustomRouter();
    router.resolve = newRouter.resolve;
};

export default router;
