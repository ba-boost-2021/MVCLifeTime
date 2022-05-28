<template>
  <button class="btn btn-primary mb-2" @click="load" :disabled="!canRefresh">
    <span class="fa-solid fa-refresh"></span> Yenile
  </button>
  <table class="table table-striped table-bordered">
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
import axios from "axios";
export default {
  name: "List",
  data() {
    return {
      employees: [],
      canRefresh: true,
    };
  },
  mounted() {
    this.load();
  },
  methods: {
    load() {
      axios.get("https://localhost:7000/api/employee/list").then((d) => {
        this.employees = d.data;
        this.canRefresh = false;
        setTimeout(() => {
          this.canRefresh = true;
        }, 3000);
      });
    },
  },
};
</script>
