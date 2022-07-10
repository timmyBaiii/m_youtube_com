
<template lang='pug'>
div(class="appWapper")
    Navbar
    AppMain
</template>

<script>
// components
import { Navbar, AppMain } from './components/index.js';

export default {
    name: 'Layout',
    components: {
        Navbar,
        AppMain
    }
};
</script>
