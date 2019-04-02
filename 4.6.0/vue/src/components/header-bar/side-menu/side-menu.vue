<template>
  <div class="side-menu-wrapper">
    <slot></slot>
    <Menu
      ref="menu"
      active-name="path"
      :open-names="openedNames"
      :accordion="accordion"
      theme="light"
      width="auto"
      mode="horizontal"
      @on-select="handleSelect"
    >
      <template v-for="item in menuList">
        <template v-if="item.children && item.children.length === 1">
          <side-menu-item v-if="showChildren(item)" :key="`menu-${item.name}`" :parent-item="item"></side-menu-item>
          <menu-item
            v-else
            :name="getNameOrHref(item, true)"
            :key="`menu-${item.children[0].name}`"
          >
            <i class="iconfont" v-html="item.children[0].icon"></i>
            <span>{{ item.children[0].name }}</span>
          </menu-item>
        </template>
        <template v-else>
          <side-menu-item v-if="showChildren(item)" :key="`menu-${item.name}`" :parent-item="item"></side-menu-item>
          <menu-item v-else :name="getNameOrHref(item)" :key="`menu-${item.name}`">
            <i class="iconfont" v-html="item.icon"></i>
            <span>{{ item.name }}</span>
          </menu-item>
        </template>
      </template>
    </Menu>
  </div>
</template>
<script>
import SideMenuItem from "./side-menu-item.vue";
import { getUnion } from "@/lib/tools";
import mixin from "./mixin";
export default {
  name: "SideMenu",
  mixins: [mixin],
  components: {
    SideMenuItem
  },
  props: {
    menuList: {
      type: Array,
      default() {
        return [];
      }
    },
    rootIconSize: {
      type: Number,
      default: 20
    },
    iconSize: {
      type: Number,
      default: 16
    },
    accordion: Boolean,
    openNames: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      openedNames: [],
      activeName: "path"
    };
  },
  methods: {
    handleSelect(name) {
      this.$emit("on-select", name);
    },
    getOpenedNamesByActiveName(name) {
      return this.$route.matched
        .map(item => item.name)
        .filter(item => item !== name);
    },
    updateOpenName(name) {
      if (name === this.$config.homeName) this.openedNames = [];
      else this.openedNames = this.getOpenedNamesByActiveName(name);
    }
  },
  computed: {
    textColor() {
      return this.theme === "dark" ? "#fff" : "#495060";
    }
  },
  watch: {
    activeName(name) {
      if (this.accordion)
        this.openedNames = this.getOpenedNamesByActiveName(name);
      else
        this.openedNames = getUnion(
          this.openedNames,
          this.getOpenedNamesByActiveName(name)
        );
    },
    openNames(newNames) {
      this.openedNames = newNames;
    },
    openedNames() {
      this.$nextTick(() => {
        this.$refs.menu.updateOpened();
      });
    }
  },
  mounted() {
    this.openedNames = getUnion(
      this.openedNames,
      this.getOpenedNamesByActiveName(name)
    );
  }
};
</script>
<style lang="less">
@import "./side-menu.less";
</style>

