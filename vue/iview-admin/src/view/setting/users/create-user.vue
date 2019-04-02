<template>
  <Modal
    width="700"
    title="创建用户"
    :mask-closable="false"
    :value="value"
    @on-ok="create"
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
          <FormItem label="密码" prop="password">
            <Input
              v-model="user.password"
              type="password"
              autocomplete="new-password"
              :maxlength="32"
            ></Input>
          </FormItem>
          <FormItem label="确认密码" prop="confirmPassword">
            <Input
              v-model="user.confirmPassword"
              type="password"
              autocomplete="off"
              :maxlength="32"
            ></Input>
          </FormItem>
          <!-- <FormItem>
            <Checkbox v-model="user.isActive">{{L('IsActive')}}</Checkbox>
          </FormItem>-->
        </TabPane>
        <TabPane label="角色" name="roles">
          <CheckboxGroup v-model="user.roleNames">
            <Checkbox :label="role.normalizedName" v-for="role in roles" :key="role.id">
              <span>{{role.displayName}}</span>
            </Checkbox>
          </CheckboxGroup>
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
import { create, getUserRoles } from "@/api/user";
import { constants } from "fs";
import { setTimeout } from "timers";
export default {
  name: "create-user",
  props: {
    value: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      roles: [],
      user: {
        userName: "",
        name: "",
        surname: "",
        emailAddress: "",
        isActive: true,
        roleNames: [],
        password: ""
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
      }
      // roles: []
    };
  },
  mounted() {
    this.$refs.userForm.resetFields();
  },
  methods: {
    validatePassCheck(rule, value, callback) {
      if (!value) {
        callback(new Error("确认密码"));
      } else if (value !== this.user.password) {
        callback(new Error("两次输入密码啊不一致"));
      } else {
        callback();
      }
    },
    create() {
      this.$refs.userForm.validate(valid => {
        if (valid) {
          this.user.name = this.user.userName;
          this.user.surname = this.user.userName;
          create(this.user).then(res => {
            this.$emit("save-success");
            this.$emit("input", false);
          });
        }
      });
    },
    cancel() {
      this.$emit("input", false);
    },
    visibleChange(value) {
      if (!value) {
        this.$emit("input", value);
      }
      this.$refs.userForm.resetFields();

      this.roles = this.$store.state.user.roles;
    }
  }
};
</script>

