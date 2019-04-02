<template>
  <div class="header-bar">
    <SideMenu :menuList="menuList"></SideMenu>
    <div class="custom-content-con">
      <slot></slot>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "@/lib/abpbase";
import SideMenu from "./side-menu/side-menu.vue";
import "./header-bar.less";
@Component({
  components: {
      SideMenu
  }
})
export default class HeaderBar extends AbpBase {
   @Prop({required:true,type:Array}) menuList:Array<any>;
}
</script>

