<template>
  <Modal
    width="700"
    title="添加仓库"
    :mask-closable="false"
    :value="value"
    @on-ok="ok"
    @on-visible-change="visibleChange"
  >
    <Form
      ref="roleForm"
      label-position="top"
      :rules="receivingRule"
      :model="receiving"
      autocomplete="off"
    >
      <FormItem label="仓库地址" prop="name">
        <Input v-model="receiving.address" :maxlength="1000" :minlength="2"/>
      </FormItem>
    </Form>
    <div slot="footer">
      <Button @click="cancel">取消</Button>
      <Button @click="ok" type="primary" :loading="loading">确定</Button>
    </div>
  </Modal>
</template>
<script>
import { createOrUpdate, getReceiving } from "@/api/reciving";
export default {
  name: "createOrUpdate-receiving",
  components: {},
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
      loading: false,
      receiving: {
        address: ""
      },
      receivingRule: {
        address: [{ required: true, message: "地址不能为空", trigger: "blur" }]
      }
    };
  },
  methods: {
    ok() {
      createOrUpdate({ id: this.id, address: this.receiving.address }).then(
        res => {
          this.$emit("on-success");
          this.$emit("input", false);
        }
      );
    },
    cancel() {
      this.$emit("input", false);
    },
    visibleChange(value) {
      if (!value) {
        this.$emit("input", false);
      }

      if (value) {
        if (this.id > 0) {
          getReceiving(this.id).then(res => {
            this.receiving.address = res.result.address;
          });
        } else {
          this.receiving.address = "";
        }
      }
    }
  }
};
</script>

