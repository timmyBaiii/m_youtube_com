<template lang="pug">
div(class="navbar")
    div(class="container mx-auto")
        div(class="row flex flex-wrap")
            div(class="col w-full sm:w-12/12 md:w-12-12 lg:w-12/12 xl:w-12/12 xxl:w-12/12")
                div(class="d_float_left")
                    h3 Youtube

                div(class="d_float_right")
                    ul(class="menu")
                        li(class="menu_item")
                            router-link(to='/') 首頁

                        li(class="menu_item")
                            router-link(to='/loveMovie/index') 喜歡影片
</template>

<script>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

export default {
    name: 'Navbar',
    setup() {
        const router = useRouter();
        
        const routes = ref(router.options.routes);

        return {
            routes
        };
    }
};
</script>

<style lang="scss" scoped>
@import '@/styles/colors.sass';

.navbar {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    z-index: 10;
    overflow: hidden;
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: $color_white;
    padding: 15px;
    box-shadow: 0px 0px 15px lighten($color_black, 75);

    .container.mx-auto {
        .row {
            .col {
                .d_float_left {
                    float: left;
                }

                .d_float_right {
                    float: right;

                    .menu {
                        .menu_item {
                            display: inline-block;
                            
                            a {
                                display: block;
                                padding: 0px 10px;
                            }

                            a.router-link-active {
                                color: $color_blue;
                            }
                        }
                    }
                }
            }
        }
    }
}                               
</style>