import router from './router/index.js';
import { getPageTitle } from '@/utils/getPageTitle.js';
// import { getToken } from '@/utils/auth.js';

const whitelist = ['/404'];

router.beforeEach(async(to, from, next) => {
    document.title = getPageTitle(to.meta.title);
    
    const hasToken = true;

    if (hasToken) {
        next();
    }
    else {
        if (whitelist.indexOf(to.path) !== -1) {
            next();
        }
        else {
            next('/404');
        }
    }
});

router.afterEach(() => {
});
