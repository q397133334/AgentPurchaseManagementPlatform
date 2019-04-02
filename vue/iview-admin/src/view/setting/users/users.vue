<template>
  <Card shadow style="height: 100%;width: 100%;">
    <div class="search-con search-con-top" style="margin-bottom: 5px;">
      <Button @click="()=>{this.createUserModalValue=true}" type="primary">添加</Button>
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
    <create-user v-model="createUserModalValue" @save-success="getData"></create-user>
    <edit-user v-model="editUserModalValue" :id="editId" @save-success="getData"></edit-user>
  </Card>
</template>
<script>
import { mapActions } from "vuex";
import { getUserAll, deleteUser } from "@/api/user";
import createUser from "./create-user.vue";
import editUser from "./edit-user.vue";
export default {
  name: "users",
  components: {
    createUser,
    editUser
  },
  data() {
    return {
      createUserModalValue: false,
      editUserModalValue: false,
      height: "500px",
      true: true,
      loading: false,
      columns: [
        {
          title: "用户名",
          key: "userName",
          tooltip: true
        },
        {
          title: "电子邮件",
          key: "emailAddress",
          tooltip: true
        },
        {
          title: "是否激活",
          render: (h, params) => {
            return h("span", params.row.isActive ? "是" : "否");
          }
        },
        {
          title: "创建时间",
          key: "creationTime",
          render: (h, params) => {
            return h(
              "span",
              new Date(params.row.creationTime).toLocaleDateString()
            );
          }
        },
        // {
        //   title: "最后登陆时间",
        //   key: "lastLoginTime",
        //   render: (h, params) => {
        //     console.log(params.row);
        //     return h(
        //       "span",
        //       new Date(params.row.lastLoginTime).toLocaleDateString()
        //     );
        //   }
        // },
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
    this.height = window.innerHeight - 170 + "px";
    this.getData();
    //this.getRoles();
    this.$store.dispatch({
      type: "getRoles"
    });
    this.page.pageSize = abp.utils.getCookieValue("pageSize") || 10;
  },
  methods: {
    ...mapActions(["getRoles"]),
    getData() {
      console.log(this.$store.state.user.roles);
      this.loading = true;
      const _this = this;
      getUserAll(
        "",
        "",
        (this.page.pageIndex - 1) * this.page.pageSize,
        this.page.pageSize
      ).then(res => {
        console.log(res);
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
      this.editUserModalValue = true;
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

