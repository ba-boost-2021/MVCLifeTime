<template>
<nav class="navbar navbar-expand-lg bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Ana Sayfa</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Hakkımızda</a>
        </li>
      </ul>
      <div class="d-flex">
        <select class="form-control" v-model="$i18n.locale">
          <option value="tr">Türkçe</option>
          <option value="en">English</option>
        </select>
      </div>
    </div>
  </div>
  </nav>
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
          {{ $t("titles.numbers") }}
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
          {{ $t("titles.register") }}
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
          {{ $t("titles.employees") }}
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
          {{ $t("titles.order") }}
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
