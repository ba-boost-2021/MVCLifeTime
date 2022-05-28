<template>
  <div>
    <ul class="nav nav-pills mb-3 mt-5" role="tablist">
      <li class="nav-item" role="presentation">
        <button
          class="nav-link active"
          id="pills-home-tab"
          data-bs-toggle="pill"
          data-bs-target="#numbers"
          type="button"
          role="tab"
        >
          Sayılar
        </button>
      </li>
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-profile-tab"
          data-bs-toggle="pill"
          data-bs-target="#form"
          type="button"
          role="tab"
        >
          Kayıt Formu
        </button>
      </li>
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-employees-tab"
          data-bs-toggle="pill"
          data-bs-target="#employees"
          type="button"
          role="tab"
        >
          Çalışanlar
        </button>
      </li>
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-order-tab"
          data-bs-toggle="pill"
          data-bs-target="#orders"
          type="button"
          role="tab"
        >
          Sipariş
        </button>
      </li>
    </ul>
    <div class="tab-content" id="pills-tabContent">
      <div class="tab-pane fade show active" id="numbers" role="tabpanel">
        <Number :value="8" />
        <hr />
        <Number />
      </div>
      <div class="tab-pane fade" id="form" role="tabpanel">
        <RecordForm />
      </div>
      <div class="tab-pane fade" id="employees" role="tabpanel">
        <Employees />
      </div>
      <div class="tab-pane fade" id="orders" role="tabpanel">
        <Order />
      </div>
    </div>
  </div>
</template>
<script>
import Number from "./components/Number.vue";
import RecordForm from "./components/RecordForm.vue";
import Employees from "./components/Employees.vue";
import Order from "./components/Order.vue";

export default {
  components: {
    Number,
    RecordForm,
    Employees,
    Order
  },
};
</script>
