<template>
<div class="mb-3">
  <label for="username" class="form-label">Kullanıcı Adı</label>
  <input type="email" class="form-control" id="username" v-model="username">
</div>
<div class="mb-3">
  <label for="password" class="form-label">Parola</label>
  <input type="password" class="form-control" id="password" v-model="password">
</div>
<button type="button" class="btn btn-primary" @click="login">Giriş Yap</button>
</template>
<script>
export default {
    name: "Authentication",
    data() {
        return {
            username: null,
            password: null
        }
    },
    methods: {
        login() {
            this.$ajax.post("api/authentication/login", { username: this.username, password: this.password })
                      .then(d => {
                          localStorage.setItem("jwt", d.data);
                      })
        }
    }
}
</script>