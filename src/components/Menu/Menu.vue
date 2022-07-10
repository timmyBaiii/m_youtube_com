<template lang="pug">
ul(class="menu")
    slot
</template>

<script>
export default {
    name: 'Menu'
};
</script>

<style lang="sass" scoped>
@import '@/styles/colors.sass'

.menu
    // width: 100%
    margin: 0px
    background-color: $color_white
</style>
