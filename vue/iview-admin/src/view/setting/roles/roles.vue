<template>
  <Card shadow style="height: 100%;width: 100%;">
    <div class="search-con search-con-top" style="margin-bottom: 5px;">
      <Button type="primary" @click="()=>{this.createRoleModelValue=true}">添加</Button>
    </div>
    <Table
      size="small"
      :stripe="true"
      :border="true"
      :loading="loading"
      :data="data"
      :columns="columns"
    ></Table>
    <div style="margin: 10px;overflow: hidden">
      <div style="float: right;">
        <Page
          :total="page.total"
          :show-total="true"
          :show-elevator="true"
          :show-sizer="true"
          placement="top"
          :page-size-opts="[10, 50, 100]"
          size="small"
          @on-change="pageChange"
          @on-page-size-change="pageSizeChange"
        />
      </div>
    </div>
    <create-role v-model="createRoleModelValue" @save-success="getData"></create-role>
    <edit-role v-model="editRoleModalValue" :id="editId" @save-success="getData"></edit-role>
  </Card>
</template>
<script>
import { getRoles, deleteRole } from "@/api/role";
import createRole from "./create-role.vue";
import editRole from "./edit-role.vue";
export default {
  components: {
    createRole,
    editRole
  },
  name: "roles",
  data() {
    return {
      createRoleModelValue: false,
      editRoleModalValue: false,
      height: "500px",
      true: true,
      loading: false,
      columns: [
        {
          title: "角色名",
          key: "name",
          tooltip: true
        },
        {
          title: "显示名称",
          key: "displayName",
          tooltip: true
        },
        {
          title: "操作",
          key: "action",
          fixed: "right",
          width: 120,
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
                  on: {
                    click: () => {
                      this.edit(params.row.id);
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
                  on: {
                    click: () => {
                      this.d(params.row.id);
                    }
                  }
                },
                "删除"
              )
            ]);
          }
        }
      ],
      page: {
        total: 0,
        pageSize: 10,
        pageIndex: 1
      },
      data: [],
      editId: 0
    };
  },
  mounted() {
    this.getData();
  },
  methods: {
    getData() {
      this.loading = true;
      getRoles(
        "",
        (this.page.pageIndex - 1) * this.page.pageSize,
        this.page.pageSize
      ).then(res => {
        this.data = res.result.items;
        this.page.total = res.result.totalCount;
        this.loading = false;
      });
    },
    pageChange(pageIndex) {
      this.page.pageIndex = pageIndex;
      this.getData();
    },
    pageSizeChange(pageSize) {
      this.page.pageSize = pageSize;
      abp.utils.setCookieValue("pageSize", pageSize);
      this.getData();
    },
    edit(id) {
      this.editId = id;
      this.editRoleModalValue = true;
    },
    d(id) {
      this.$Modal.confirm({
        title: "删除提示",
        content: "确定要删除吗",
        okText: "是",
        cancelText: "否",
        onOk: () => {
          deleteUser(id).then(res => {
            this.getData();
          });
        }
      });
    }
  }
};
</script>

