import { createApp } from 'vue';
import store from './store';
import router from './router';

import '@/styles/tailwind.scss';
import '@/styles/index.sass';

import App from './App.vue';

createApp(App)
    .use(store)
    .use(router)
    .mount('#app');
