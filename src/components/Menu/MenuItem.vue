<template lang="pug">
li(class="menuItem" :class="subMenu === 'subMenu'? 'subMenu': ''")
    slot
</template>

<script>
export default {
    name: 'menuItem',
    inject: ['subMenu']
};
</script>

<style lang="scss" scoped>
@import '@/styles/colors.sass';

.menuItem {
    position: relative;
    display: inline-block;
    padding: 14px 0px;
    color: $color_blue;
    cursor: pointer;
    font-size: 16px;
    transition: 0.5s;
    
    &:hover {
        color: $color_pink;
    }
}

.menuItem.subMenu {
    position: relative;
    display: block;
    padding: 14px 10px;
    color: $color_purple;
    cursor: pointer;
    font-size: 14px;
    font-weight: 900;
    transition: 0.5s;

    &:hover
        padding: 16px 14px;
}
</style>
