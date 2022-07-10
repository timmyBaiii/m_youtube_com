/**
 * 檢查影片索引
 * @param {Array} movies 影片清單
 * @param {Object} item 目標查詢影片
 */
const filterMovie = (movies, item) => {
    let res = 0;

    movies.forEach((movie, index) => {
        if (movie.id === item.id)
            res = index;
    });
    
    return res;
};

const state = {
    movies: [
        {
            id: 295187,
            title: '【黃阿瑪的後宮生活】小花大戰飛蟲！過程超驚險！',
            image: require('@/assets/jpg/295187.jpg'),
            youtubeLogo: require('@/assets/logo/295187.jpg'),
            movieLink: 'https://www.youtube.com/watch?v=ta8Y7t-Yy5I',
            channelName: '黃阿瑪的後宮生活',
            channelLink: 'https://www.youtube.com/channel/UCw2W7GIqJNB-UMUxncnMuiw',
            viewers: '3.9 萬次',
            movieType: '人物與網誌',
            love: true
        },
        {
            id: 808790,
            title: 'キタニタツヤ - ちはる feat. n-buna from ヨルシカ / THE FIRST TAKE',
            image: require('@/assets/jpg/808790.jpg'),
            youtubeLogo: require('@/assets/logo/808790.jpg'),
            movieLink: 'https://www.youtube.com/watch?v=XTTDTt41FBE',
            channelName: 'THE FIRST TAKE',
            channelLink: 'https://www.youtube.com/channel/UC9zY_E8mcAo_Oq772LEZq8Q/videos',
            viewers: '3.9 萬次',
            movieType: '音樂',
            love: true
        },
        {
            id: 536026,
            title: '我花九萬元買了一個「實體的」NFT',
            image: require('@/assets/jpg/536026.jpg'),
            youtubeLogo: require('@/assets/logo/536026.jpg'),
            movieLink: 'https://www.youtube.com/watch?v=iO3WvV86lS0',
            channelName: '啾啾鞋',
            channelLink: 'https://www.youtube.com/c/chuchushoeTW',
            viewers: '3.9 萬次',
            movieType: '知識',
            love: false
        },
        {
            id: 276286,
            title: 'Data Analysis with Python Course - Numpy, Pandas, Data Visualization',
            image: require('@/assets/jpg/276286.jpg'),
            youtubeLogo: require('@/assets/logo/276286.jpg'),
            movieLink: 'https://www.youtube.com/watch?v=GPVsHOlRBBI',
            channelName: 'freeCodeCamp.org',
            channelLink: 'https://www.youtube.com/c/Freecodecamp',
            viewers: '3.9 萬次',
            movieType: '數學',
            love: false
        },
        {
            id: 127701,
            title: 'Data Visualization with D3, JavaScript, React - Full Course [2021]',
            image: require('@/assets/jpg/127701.jpg'),
            youtubeLogo: require('@/assets/logo/276286.jpg'),
            movieLink: 'https://www.youtube.com/watch?v=2LhoCfjm8R4',
            channelName: 'freeCodeCamp.org',
            channelLink: 'https://www.youtube.com/c/Freecodecamp',
            viewers: '3.9 萬次',
            movieType: '數學',
            love: false
        }
    ]
};

const mutations = {
    TOGGLE_LOVE_MOVIE: (state, index) => {
        if (state.movies[index].love) {
            state.movies[index].love = false;
        }
        else {
            state.movies[index].love = true;
        }
    },
    DELETE_LOVE_MOVIE: (state, index) => {
        state.movies[index].love = false;
    }
};

const actions = {
    toggle_love_movie: ({commit, state}, movie) => {
        const index = filterMovie(state.movies, movie);
        
        commit('TOGGLE_LOVE_MOVIE', index);
    },
    delete_love_move: ({commit}, movie) => {
        const index = filterMovie(state.movies, movie);
        commit('DELETE_LOVE_MOVIE', index);
    }
};

export default {
    namespaced: true,
    state,
    mutations,
    actions
};
