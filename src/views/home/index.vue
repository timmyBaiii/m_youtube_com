<template lang="pug">
div(class="home")
    div(class="container mx-auto")
        div(class="flex flex-wrap row")
            div(class="col w-full sm:w-12/12 md:w-6/12 lg:w-3/12 xl:w-3/12 xxl:w-3/12" v-for="(movie) in storeGetters.movies" :key="movie.id")
                div(class="card")
                    //- 影片資訊
                    div(class="info")
                        div(class="flex flex-wrap")
                            div(class="w-full sm:w-12/12")
                                img(class="movie" :src="movie.image")

                            div(class="sm:w-2/12")
                                img(class="youtubeLogo" :src="movie.youtubeLogo")
                            
                            div(class="col sm:w-10/12" style="width: 80%")
                                    h5(class="title" v-text="movie.title")
                                    img(class="love"
                                        :src="lovePhoto = movie.love ? require('@/assets/png/redLove.png'): require('@/assets/png/whiteLove.png')"
                                        @mouseover="handleMouseEnterLove(movie, $event)"
                                        @mouseleave="handleMouseLeaveLove(movie, $event)"
                                        @click="handleChangeLove(movie)"
                                    )

                                    p(class="viewers" v-text="`觀看次數: ${movie.viewers}`")           
</template>

<script>
import { computed } from 'vue';
import { useStore } from 'vuex';

export default {
    name: 'home',
    setup() {
        const store = useStore();

        const handleMouseEnterLove = (item, e) => {
            if (item.love === true) {
                e.target.src = require('@/assets/png/whiteLove.png');
            }
            else {
                e.target.src = require('@/assets/png/redLove.png');
            }
        };

        const handleMouseLeaveLove = (item, e) => {
            if (item.love === true) {
                e.target.src = require('@/assets/png/redLove.png');
            }
            else {
                e.target.src = require('@/assets/png/whiteLove.png');
            }
        };

        const handleChangeLove = (item) => {
            store.dispatch('app/toggle_love_movie', item);
        };

        // 影片集，兩張表 left join 合併成此格式
        const storeGetters = computed(() => {
            return {
                movies: store.getters.movies
            };
        });

        return {
            // methods
            handleMouseEnterLove,
            handleMouseLeaveLove,
            handleChangeLove,
            // computed
            storeGetters
        };
    }
};
</script>

<style lang="scss" scoped>
.home {
    .container {
        padding: 20px 0px;

        .row {
            .col {
                .card {
                    padding: 10px;

                    .info {
                        overflow: hidden;

                        .youtubeLogo {
                            border-radius: 50%;
                            margin: 5px 0px;
                        }

                        .movie {
                            width: 100%;
                            border-radius: 15px;
                        }

                        .love {
                            width: 20px;
                            float: right;
                            margin-top: 8px;
                            cursor: pointer;
                        }

                        .title, .viewers {
                            padding: 5px;
                        }
                    }
                }
            }
        }
    }
}
</style>