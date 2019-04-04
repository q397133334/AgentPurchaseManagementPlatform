<template>
  <Modal
    width="700"
    title="添加收货人"
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
      <FormItem label="收货人" prop="name">
        <Input v-model="receiving.name" :maxlength="1000" :minlength="2"/>
      </FormItem>
    </Form>
    <div slot="footer">
      <Button @click="cancel">取消</Button>
      <Button @click="ok" type="primary" :loading="loading">确定</Button>
    </div>
  </Modal>
</template>
<script>
import { createOrUpdatePersion, getPersion } from "@/api/reciving";
export default {
  name: "createOrUpdate-receivingPersion",
  components: {},
  props: {
    id: {
      type: Number,
      default: 0
    },
    receivingId: {
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
        name: ""
      },
      receivingRule: {
        name: [{ required: true, message: "收货人不能为空", trigger: "blur" }]
      }
    };
  },
  methods: {
    ok() {
      createOrUpdatePersion({ id: this.id, name: this.receiving.name,receivingId:this.receivingId }).then(
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
          getPersion(this.id).then(res => {
            this.receiving.name = res.result.name;
          });
        } else {
          this.receiving.name = "";
        }
      }
    }
  }
};
</script>

