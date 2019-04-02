<template>
  <Modal
    width="700"
    title="创建角色"
    :mask-closable="false"
    :value="value"
    @on-ok="create"
    @on-visible-change="visibleChange"
  >
    <Form ref="roleForm" label-position="top" :rules="roleRule" :model="role" autocomplete="off">
      <Tabs value="detail">
        <TabPane label="详情" name="detail">
          <FormItem label="角色名称" prop="name">
            <Input v-model="role.name" :maxlength="32" :minlength="2"/>
          </FormItem>
          <FormItem label="显示名称" prop="displayName">
            <Input v-model="role.displayName" :maxlength="32" :minlength="2"/>
          </FormItem>
          <FormItem label="说明" prop="description">
            <Input v-model="role.description" :maxlength="1024"/>
          </FormItem>
        </TabPane>
        <TabPane label="权限" name="roles">
          <Tree :data="permissionTree" :show-checkbox="true" @on-check-change="treeChange"></Tree>
        </TabPane>
      </Tabs>
    </Form>
    <div slot="footer">
      <Button @click="cancel">取消</Button>
      <Button @click="create" type="primary" :loading="loading">确定</Button>
    </div>
  </Modal>
</template>
<script>
import { getPermissions, createRole } from "@/api/role";
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
      loading: false,
      permissionTree: [],
      role: {
        name: "",
        displayName: "",
        normalizedName: "",
        description: "",
        permissions: []
      },
      roleRule: {
        name: [
          {
            required: true,
            message: "角色名称不能为空",
            trigger: "blur"
          }
        ],
        displayName: [
          {
            required: true,
            message: "显示名称不能为空",
            trigger: "blur"
          }
        ]
      }
    };
  },
  mounted() {
    getPermissions().then(res => {
      this.permissionTree = permissionToTree("", res.result, []);
    });
  },
  methods: {
    treeChange(checked) {
      this.role.permissions = [];
      checked.forEach(c => {
        this.role.permissions.push(c.data.name);
      });
      console.log(this.role);
    },
    cancel() {
      this.$emit("input", false);
    },
    create() {
      this.$refs.roleForm.validate(valid => {
        if (valid) {
          if (!this.role.permissions) {
            this.role.permissions = [];
          }
          this.loading = true;
          createRole(this.role).then(res => {
            this.$refs.roleForm.resetFields();
            this.$emit("save-success");
            this.$emit("input", false);
            this.loading = false;
          });
        }
      });
    },
    visibleChange(value) {
      if (!value) {
        this.$emit("input", value);
      }
      if (value) {
        this.role.permissions = [];
        getPermissions().then(res => {
          this.permissionTree = permissionToTree("", res.result, []);
        });
      }
    }
  }
};
</script>

