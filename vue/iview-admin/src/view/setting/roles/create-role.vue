<template>
  <Modal
    width="700"
    title="创建角色"
    :mask-closable="false"
    :value="value"
    @on-ok="create"
    @on-visible-change="visibleChange"
  >
    <Form ref="roleForm" label-position="top" :model="role" autocomplete="off">
      <Tabs value="detail">
        <TabPane label="详情" name="detail">
          <!-- <FormItem>
            <Checkbox v-model="user.isActive">{{L('IsActive')}}</Checkbox>
          </FormItem>-->
        </TabPane>
        <TabPane label="权限" name="roles">
          <Tree :data="permissionTree" :show-checkbox="true" @on-check-change="treeChange"></Tree>
        </TabPane>
      </Tabs>
    </Form>
    <div slot="footer">
      <Button @click="cancel">取消</Button>
      <Button @click="create" type="primary">确定</Button>
    </div>
  </Modal>
</template>
<script>
import { getPermissions } from "@/api/role";
import { permissionToTree } from "./permissionToTree";
export default {
  name: "role-edit",
  props: {
    value: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      permissionTree: [],
      role: []
    };
  },
  mounted() {
    getPermissions().then(res => {
      this.permissionTree = permissionToTree("", res.result, []);
    });
  },
  methods: {
    create() {},
    visibleChange(value) {
      if (value) {
        getPermissions().then(res => {
          this.permissionTree = permissionToTree("", res.result, []);
        });
      }
    }
  }
};
</script>

