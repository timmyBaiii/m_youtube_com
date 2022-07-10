<template lang="pug">
section(class="AppMain")
    router-view
</template>

<script>
export default {
    name: 'AppMain'
};
</script>

<style lang="sass" scoped>
.AppMain
    height: 100vh
    margin-top: 56px
</style>