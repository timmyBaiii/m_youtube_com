module.exports = {
    env: {
        'browser': true,
        'node': true,
        'commonjs': true,
        'es6': true,
        'es2016': true,
        'es2017': true,
        'es2018': true,
        'es2019': true,
        'es2020': true,
        'es2021': true,
        'es2022': true
    },
    extends: [
        'eslint:recommended',
        'plugin:vue/essential'
    ],
    parserOptions: {
        'ecmaVersion': 'latest',
        'sourceType': 'module'
    },
    plugins: [
        'vue'
    ],
    overrides: [
        {
            'files': '*.vue',
            'rules': {
                'indent': ['error', 4, { 'SwitchCase': 1 }],
                'no-control-regex': 0
            }
        },
        {
            'files': '*.js',
            'rules': {
                'indent': ['error', 4, { 'SwitchCase': 1 }],
                'no-control-regex': 0
            }
        },
        {
            'files': '*.ts',
            'rules': {
                'indent': ['error', 4, { 'SwitchCase': 1 }],
                'no-control-regex': 0
            }
        },
        {
            'files': [ '*.sass', '*.scss' ],
            'rules': {
                'indent': ['error', 4, { 'SwitchCase': 1 }]
            }
        }
    ],
    rules: {
        // 在元素內容之前後強制換行
        'vue/singleline-html-element-content-newline': 'off',
        // 多元元素強制換行
        'vue/multiline-html-element-content-newline': 'off',
        // 禁止使用 v-html 防止 xss 風險
        'vue/no-v-html': 'off',
        // 元件取名多個單字
        'vue/multi-word-component-names': 'off',
        // 檢查模板是否包含 vue2 元素
        'vue/no-multiple-template-root': 'error',
        'vue/no-reserved-component-names': 'off',
        // 檢查未使用變數，'vars': 'all' 檢查所有變數情況。'args': 'none' 不需檢查參數
        'no-unused-vars': ['error', {
            'vars': 'all',
            'args': 'none'
        }],
        // 禁止帶有 new Object 運算符
        'no-new-object': 'error',
        // 禁止重複 key 值
        'no-dupe-keys': 'error',
        // 禁止多餘空格
        'no-multi-spaces': 'error',
        // 禁制重新設定 const 變數
        'no-const-assign': 'error',
        // 禁止函式宣告同名參數
        'no-dupe-args': 'error',
        // 禁止引入重複模組
        'no-duplicate-imports': 'error',
        // 禁止解構式為空
        'no-empty-pattern': 'error',
        // 禁止不規則控隔
        'no-irregular-whitespace': 'error',
        // 強制 switch 語句必須 default 情況
        'default-case': 'error',
        // 禁止使用 eval 語句
        'no-eval': 'error',
        // 禁止使用類似 eval 語句
        'no-implied-eval': 'error',
        // 禁止不必要的分號
        'no-extra-semi': 'error',
        // 禁制變數重新宣告
        'no-redeclare': 'error',
        // 禁止使用 var 關鍵字，宣告變數
        'no-var': 'error',
        // 禁止不必要的括號
        'no-extra-parens': 'error',
        // 強制一致逗號樣式
        // 強制必須加分號
        'semi': ['error', 'always'],
        // 強制使用單引號
        'quotes': ['error', 'single'],
        // 箭頭函式前後皆須空白
        'arrow-spacing': ['error', {
            'before': true,
            'after': true
        }],
        // 大括號擺放樣式
        'brace-style': ['error', 'stroustrup'],
        'comma-style': ['error', 'last'],
        'block-spacing': ['error', 'never'],
        'no-undef': 'off',
    }
};
