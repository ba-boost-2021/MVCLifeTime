<template>
  <h3>Çalışanlar</h3>
  <hr />
  <div class="row">
    <div class="col-4">
      <New @saved="newEmployeeSaved" />
    </div>
    <div class="col-8">
      <List ref="employeeList" />
    </div>
  </div>
</template>
<script>
import New from "./Employees/New.vue";
import List from "./Employees/List.vue";
export default {
  name: "Employees",
  components: {
    New,
    List,
  },
  methods: {
    newEmployeeSaved() {
        //PARENT COMPONENT'tan CHILD COMPONENT'a veri göndwerme veya bir iş yaptırmanın yollarından birisi $ref kullanımdır
        this.$refs.employeeList.load(); // Bakınız List.vue methods -> load 
    },
  },
};
</script>
