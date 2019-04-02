<template>
  <Modal
    width="700"
    title="编辑用户"
    :mask-closable="false"
    :value="value"
    @on-ok="edit"
    @on-visible-change="visibleChange"
  >
    <Form ref="userForm" label-position="top" :rules="userRule" :model="user" autocomplete="off">
      <Tabs value="detail">
        <TabPane label="详情" name="detail">
          <FormItem label="用户名" prop="userName">
            <Input v-model="user.userName" :maxlength="32" :minlength="2"></Input>
          </FormItem>
          <FormItem label="电子邮件" prop="emailAddress">
            <Input v-model="user.emailAddress" autocomplete="off" :maxlength="32"></Input>
          </FormItem>
          <!-- <FormItem>
            <Checkbox v-model="user.isActive">{{L('IsActive')}}</Checkbox>
          </FormItem>-->
        </TabPane>
        <TabPane label="角色" name="roles">
          <CheckboxGroup v-model="user.roleNames">
            <Checkbox :label="role.normalizedName" v-for="role in roles" :key="role.id">
              <span>{{role.name}}</span>
            </Checkbox>
          </CheckboxGroup>
        </TabPane>
      </Tabs>
    </Form>
    <div slot="footer">
      <Button @click="cancel">取消</Button>
      <Button @click="edit" type="primary">确定</Button>
    </div>
  </Modal>
</template>
<script>
import { getUser } from "@/api/user";
import { constants } from 'fs';
export default {
  name: "edit-user",
  props: {
    id: {
      type: Number,
      default: 0
    },
    value: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      user: {
        id: 0,
        userName: "",
        name: "",
        surname: "",
        emailAddress: "",
        isActive: true,
        roleNames: []
      },
      userRule: {
        userName: [
          {
            required: true,
            message: "用户名不能为空",
            trigger: "blur"
          }
        ],
        name: [
          {
            required: true,
            message: this.L("FieldIsRequired", undefined, this.L("Name")),
            trigger: "blur"
          }
        ],
        surname: [
          {
            required: true,
            message: this.L("FieldIsRequired", undefined, this.L("Surname")),
            trigger: "blur"
          }
        ],
        emailAddress: [
          {
            required: true,
            message: "电子邮件不能为空",
            trigger: "blur"
          },
          { type: "email", message: "电子邮件格式错误" }
        ],
        password: [
          {
            required: true,
            message: "密码不能为空",
            trigger: "blur"
          }
        ],
        confirmPassword: { validator: this.validatePassCheck, trigger: "blur" }
      },
      roles: []
    };
  },
  mounted() {},
  methods: {
    getUser() {
      getUser(this.id).then(res => {
        this.user = res.data.result;
      });
    },
    edit() {},
    cancel() {
      this.$emit("input", false);
    },
    visibleChange(value) {
      if (!value) {
        this.$emit("input", value);
      }
      console.log(this.id);
      if (value) {
        this.roles = this.$store.state.user.roles;
        if (this.id > 0) {
          getUser(this.id).then(res => {
              console.log(res)
            this.user = res.result;
          });
        }
      }
    }
  }
};
</script>

