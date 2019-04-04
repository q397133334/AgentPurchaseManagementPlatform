<template>
  <Card shadow style="height: 100%;width: 100%;">
    <div class="search-con search-con-top" style="margin-bottom: 5px;">
      <Button
        type="primary"
        @click="()=>{this.editId=0; this.createOrUpdateReceivingModelValue=true}"
        style="margin-right:5px;"
      >添加仓库</Button>
      <Button
        type="primary"
        @click="()=>{if(this.currentId==0){  this.$Message.error('请选择仓库信息后添加'); return; } this.createOrUpdateReceivingPersionModelValue=true}"
      >添加收货人</Button>
    </div>
    <Row :gutter="16">
      <Col span="12">
        <Table
          highlight-row
          @on-current-change="selectReceiving"
          size="small"
          :stripe="true"
          :border="true"
          :loading="loading"
          :data="receivingData"
          :columns="receivingColums"
        />
      </Col>
      <Col span="12">
        <Table
          size="small"
          :stripe="true"
          :border="true"
          :loading="loading"
          :columns="receivingPersoinColums"
          :data="receivingPersionData"
        />
      </Col>
    </Row>
    <create-or-update-receiving
      @on-success="this.getReceivingData"
      v-model="createOrUpdateReceivingModelValue"
      :id="editId"
    ></create-or-update-receiving>
    <create-or-update-receiving-persion
      @on-success="this.getPersionsData"
      v-model="createOrUpdateReceivingPersionModelValue"
      :id="editId"
      :receivingId="currentId"
    />
  </Card>
</template>

<script>
import { getReceivings, deleteRevicing, getPersions } from "@/api/reciving";
import createOrUpdateReceiving from "./createOrUpdate-receiving";
import createOrUpdateReceivingPersion from "./createOrUpdate-receivintPersion";
export default {
  name: "receiving-list",
  components: {
    createOrUpdateReceiving,
    createOrUpdateReceivingPersion
  },
  data() {
    return {
      createOrUpdateReceivingModelValue: false,
      createOrUpdateReceivingPersionModelValue: false,
      editId: 0,
      loading: false,
      currentId: 0,
      receivingColums: [
        {
          type: "index",
          width: 60,
          align: "center"
        },
        {
          title: "收货地址",
          key: "address",
          tooltip: true
        },
        {
          title: "操作",
          key: "action",
          fixed: "right",
          width: 180,
          render: (h, params) => {
            return h("div", [
              h(
                "Button",
                {
                  props: {
                    type: "primary",
                    size: "small"
                    // icon:"md-create"
                  },
                  style: {
                    marginRight: "2px"
                  },
                  on: {
                    click: () => {
                      this.editId = params.row.id;
                      this.createOrUpdateReceivingModelValue = true;
                    }
                  }
                },
                "编辑"
              ),
              h(
                "Button",
                {
                  props: {
                    type: "error",
                    size: "small"
                  },
                  style: {
                    marginRight: "2px"
                  },
                  on: {
                    click: () => {
                      this.$Modal.confirm({
                        title: "删除提示",
                        content: "确定要删除吗",
                        okText: "是",
                        cancelText: "否",
                        onOk: () => {
                          deleteRevicing(params.row.id).then(res => {
                            this.getReceivingData();
                          });
                        }
                      });
                    }
                  }
                },
                "删除"
              )
            ]);
          }
        }
      ],
      receivingPersoinColums: [
        {
          type: "index",
          width: 60,
          align: "center"
        },
        {
          title: "收货人",
          key: "name",
          tooltip: true
        }
      ],
      receivingData: [],
      receivingPersionData: []
    };
  },
  mounted() {
    this.getReceivingData();
  },
  methods: {
    getReceivingData() {
      getReceivings().then(res => {
        this.receivingData = res.result;
        this.receivingData = res.result.map(i => {
          if (i.id == this.currentId) {
            i._highlight = true;
          }
          return i;
        });
        console.log(this.receivingData);
      });
    },
    getPersionsData() {
      getPersions(this.currentId).then(res => {
        this.receivingPersionData = res.result;
      });
    },
    selectReceiving(current, old) {
      this.currentId = current.id;
      this.getPersionsData();
    }
  }
};
</script>
