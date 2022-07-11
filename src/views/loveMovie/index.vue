<template lang="pug">
div(class="loveMovie")
    div(class="container mx-auto")
        div(class="flex flex-warp row")
            //- 喜歡影片
            div(class="w-full sm:w-4/12 col") 喜歡影片
            
            //- 影片列表
            div(class="w-full sm:w-8/12 col")
                div(class="flex flex-wrap moveListGrid" v-for="(item, index) in loveMove" :key="item.id")
                    div(class="w-full sm:w-10/12 moveListColumn")
                        div(class="number")
                            p(v-text="index + 1")

                        div(class="content")
                            div(class="movieImg")
                                img(:src="item.image")

                            div(class="movieInfo")
                                h3(class="title" v-text="item.title")
                                h4(class="subTitle" v-text="item.channelName")

                    div(class="w-full sm:w-2/12 moveListColumn")
                        button(class="btnRemove" @click="handleRemoeLoveMovie(item)") 移除
</template>

<script>
import { computed } from 'vue';
import { useStore } from 'vuex';

export default {
    setup() {
        // vue
        const store = useStore();

        // 刪除喜歡影片
        const handleRemoeLoveMovie = (item) => {
            store.dispatch('app/delete_love_move', item);
        };

        // get vuex getters
        const storeGetters = computed(() => {
            return {
                movies: store.getters.movies
            };
        });

        // 篩選喜歡影片
        const loveMove = computed(() => {
            return storeGetters.value.movies.filter(item => item.love === true );
        });

        return {
            // data
            // methods
            handleRemoeLoveMovie,
            // computed
            storeGetters,
            loveMove
        };
    }
};
</script>

<style lang="scss" scoped>
@import '@/styles/colors.sass';

.loveMovie {
    .container {
        padding: 20px 00px;

        .row {
            .col {
                .moveListGrid {
                    .moveListColumn {
                        display: flex;
                        align-items: center;
                        background-color: #f1f1f1;
                        
                        .number {
                            padding: 5px;
                        }
                        
                        .content {
                            display: flex;
                            justify-content: center;
                            padding: 10px;
                            border-bottom: 1px solid #d9d9d9;

                            .movieImg {
                                flex: none;

                                img {
                                    display: block;
                                    max-width: 150px;
                                }
                            }

                            .movieInfo {
                                .title, .subTitle {
                                    padding: 0px 10px;
                                }

                                .title {
                                    font-size: 16px;
                                    font-weight: 700;
                                }

                                .subTitle {
                                    font-size: 14px;
                                    font-weight: 400;
                                }
                            }
                        }
                            
                        .btnRemove {
                            background-color: #1C5D99;
                            color: $color_white;
                            padding: 5px 20px;
                            border-radius: 6px;
                        }
                    }
                }
            }
        }
    }
}
</style>