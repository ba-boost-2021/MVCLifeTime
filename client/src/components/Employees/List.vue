<template>
  <button class="btn btn-primary mb-2" @click="load" :disabled="!canRefresh">
    <span class="fa-solid fa-refresh"></span> {{ $t("common.refresh") }}
  </button>
  <div class="alert alert-warning" role="alert" v-if="unauthorized">
    Verileri görebilmeniz için giriş yapınız!
  </div>
  <table class="table table-striped table-bordered" v-else>
    <thead>
      <tr>
        <th>Adı Soyadı</th>
        <th>Ülke</th>
        <th>Şehir</th>
        <th>Telefon</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="e in employees" :key="e.id">
        <td>{{ e.firstName }} {{ e.lastName }}</td>
        <td>{{ e.country }}</td>
        <td>{{ e.city }}</td>
        <td>{{ e.homePhone }}</td>
      </tr>
    </tbody>
  </table>
</template>
<script>
export default {
  name: "List",
  data() {
    return {
      employees: [],
      canRefresh: true,
      unauthorized: false,
    };
  },
  mounted() {
    this.load();
  },
  methods: {
    load() {
      this.unauthorized = false;
      this.employees = [];
      this.$ajax
        .get("api/employee/list")
        .then((d) => {
          this.employees = d.data;
          this.canRefresh = false;
          setTimeout(() => {
            this.canRefresh = true;
          }, 3000);
        })
        .catch(() => {
          this.unauthorized = true;
        });
    },
  },
};
</script>
