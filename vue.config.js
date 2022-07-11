const path = require('path');
const defaultSettings = require('./src/settings.js');

const name = defaultSettings.title || 'vue base framework';
const port = process.env.PORT;

module.exports = {
    publicPath: '/',
    outputDir: 'dist',
    assetsDir: 'static',
    productionSourceMap: false,
    lintOnSave: process.env.NODE_ENV === 'development',
    devServer: {
        open: false,
        host: '0.0.0.0',
        port: port
    },
    configureWebpack: {
        name: name,
        resolve: {
            alias: {
                '@': path.resolve(__dirname, 'src')
            }
        }
    }
};
