<template lang="pug">
li(class="subMenu")
    slot(name="title")
        ol
            slot
</template>

<script>
export default {
    name: 'subItem',
    provide: {
        subMenu: 'subMenu'
    }
};
</script>

<style lang="scss" scoped>
@import '@/styles/colors.sass'

.subMenu {
    position: relative;
    display: inline-block;
    padding: 20px 10px;
    color: $color_blue;
    cursor: pointer;
    font-size: 16px;
    transition: 0.5s;

    &:hover {
        color: $color_pink
    }

        .nestMenu {
            opacity: 1;
            visibility: visible;
        }

    .nestMenu {
        position: absolute;
        top: 58px;
        left: 0px;
        width: 150px;
        background-color: $color_pink;
        color: $color_purple;
        font-weight: 600;
        border-radius: 0px 0px 5px 5px;
        opacity: 0;
        visibility: hidden;
        transition: 0.5s;
    }
}
</style>
