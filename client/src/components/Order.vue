<template>
  <div class="card">
    <div class="card-body">
      <h5 class="card-title">Yeni Sipariş</h5>
      <div class="mb-3">
        <label class="form-label">Ürün Türü</label>
        <select class="form-control" v-model="categoryId" @change="categoryChanged">
          <option v-for="c in categories" :key="c.id" :value="c.id">{{ c.name }}</option>
        </select>
      </div>
      <div class="mb-3">
        <label class="form-label">Ürün</label>
        <select
          class="form-control"
          v-model="productId"
          :disabled="categories.length === 0"
          @change="productChanged"
        >
          <option v-for="p in products" :key="p.id" :value="p.id">{{ p.name }}</option>
        </select>
      </div>
      <div class="mb-3">
        <label class="form-label">Adet</label>
        <input
          type="number"
          class="form-control"
          v-model="amount"
          :class="{ 'is-invalid': invalidStock }"
        />
        <em v-if="productId !== null">Stok Miktarı : {{ stock }}</em>
      </div>
      <div class="mb-3">
        <label class="form-label">Fiyat</label>
        <input type="number" class="form-control" v-model="price" />
      </div>
      <button type="button" class="btn btn-primary me-2" @click="save">
        <span class="fa-solid fa-save"></span> Kaydet
      </button>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  name: "Order",
  data() {
    return {
      categoryId: null,
      categories: [],
      productId: null,
      products: [],
      price: null,
      amount: null,
      stock: null,
      invalidStock: false,
    };
  },
  mounted() {
    axios.get("https://localhost:7000/api/product/categories").then((response) => {
      this.categories = response.data;
    });
  },
  methods: {
    save() {
      this.invalidStock = false;
      if (this.amount > this.stock) {
        this.invalidStock = true;
        return;
      }
    },
    categoryChanged() {
      this.price = null;
      this.amount = null;
      this.stock = null;
      this.products = [];
      axios
        .get(`https://localhost:7000/api/product/filter2?categoryId=${this.categoryId}`)
        .then((response) => {
          this.products = response.data;
        });
    },
    productChanged() {
      this.price = null;
      this.amount = null;
      this.stock = null;
      axios
        .get(`https://localhost:7000/api/product/info/${this.productId}`)
        .then((response) => {
          this.stock = response.data.stock;
          this.price = response.data.price;
        });
    },
  },
};
</script>
