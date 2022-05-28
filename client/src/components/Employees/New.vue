<template>
  <div class="card">
    <div class="card-body">
      <h5 class="card-title">Yeni Çalışan</h5>
      <div class="mb-3 has-validation">
        <label class="form-label">Adı *</label>
        <input type="text" class="form-control" :class="{ 'is-invalid' : validations.firstName }" v-model="firstName" maxlength="16" />
        <em class="invalid-feedback">Bu alan zorunludur</em>
      </div>
      <div class="mb-3">
        <label class="form-label">Soyadı *</label>
        <input type="text" class="form-control" :class="{ 'is-invalid' : validations.lastName }" v-model="lastName" maxlength="16" />
        <em class="invalid-feedback">Bu alan zorunludur</em>
      </div>
      <div class="mb-3">
        <label class="form-label">Ülke</label>
        <input type="text" class="form-control" v-model="country" maxlength="16" />
      </div>
      <div class="mb-3">
        <label class="form-label">Şehir</label>
        <input type="text" class="form-control" v-model="city" maxlength="16" />
      </div>
      <div class="mb-3">
        <label class="form-label">Telefon</label>
        <input type="text" class="form-control" v-model="phone" maxlength="16" />
      </div>
      <button type="button" class="btn btn-primary me-2" @click="save">
        <span class="fa-solid fa-save"></span> Kaydet
      </button>
      <button type="button" class="btn btn-danger" @click="clear">
        <span class="fa-solid fa-trash"></span> Temizle
      </button>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  name: "New",
  emits: ["saved"],
  data() {
    return {
      firstName: null,
      lastName: null,
      country: null,
      city: null,
      phone: null,
      validations: {
          firstName: false,
          lastName: false
      }
    };
  },
  methods: {
      save() {
          if(!this.isValid()) {
              return;
          }
          const employee = {
              firstName: this.firstName,
              lastName: this.lastName,
              country: this.country,
              city: this.city,
              phone: this.phone
          }
          axios.post("https://localhost:7000/api/employee/create", employee)
               .then(d => {
                   if(d.data) {
                       //CHILD COMPONENT'tan PARENT COMPONENT'a veri göndermenin tek yolu "emit"
                       this.$emit("saved");
                       this.clear();
                   }
               });
      },
      isValid() {
          this.validations.firstName = false;
          this.validations.lastName = false;
          let result = true;
          if(!this.firstName){
              this.validations.firstName = true;
              result = false;
          }
          if(!this.lastName){
              this.validations.lastName = true;
              result = false;
          }
          return result;
      },
      clear() {
          this.validations.firstName = false;
          this.validations.lastName = false;
          this.firstName = null;
          this.lastName = null;
          this.country = null;
          this.city = null;
          this.phone = null;
      }
  }
};
</script>
