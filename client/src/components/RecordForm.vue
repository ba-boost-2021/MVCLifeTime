<template>
  <div class="row">
    <div class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Kayıt Formu</h5>
          <div class="mb-3">
            <label class="form-label">Adı</label>
            <input type="text" class="form-control" v-model="name" />
          </div>
          <div class="mb-3">
            <label class="form-label">Doğum Tarihi</label>
            <input type="date" class="form-control" v-model="birthDate" />
          </div>
          <div class="mb-3">
            <label class="form-label">Cinsiyeti</label>
            <select class="form-control" v-model="gender">
              <option v-for="g in genders" :key="g.id" :value="g.id">{{ g.text }}</option>
            </select>
          </div>
          <button type="button" class="btn btn-primary me-2" @click="save">
            <span class="fa-solid fa-save"></span> Kaydet
          </button>
          <button type="button" class="btn btn-danger" @click="clear">
            <span class="fa-solid fa-trash"></span> Temizle
          </button>
        </div>
      </div>
    </div>
    <div class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Kayıt Listesi</h5>
          <table class="table">
            <tr v-for="p in people" :key="p.id">
              <td>{{p.name}}</td>
              <td>{{p.birthDate}}</td>
              <td>
                <span class="fa-solid" :class="showGender(p.gender)"></span>
              </td>
            </tr>
          </table>
          <div class="alert alert-warning" role="alert" v-if="people.length === 0">Henüz bir kayıt mevcut değil</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "RecordForm",
  data() {
    return {
      people: [],
      name: null,
      birthDate: null,
      gender: null,
      genders: [
        { id: 0, text: "Kadın" },
        { id: 1, text: "Erkek" },
      ],
    };
  },
  methods: {
    clear() {
      this.name = null;
      this.birthDate = null;
      this.gender = null;
    },
    save() {
      let person = {
        id: new Date().getTime(),
        name: this.name,
        birthDate: this.birthDate,
        gender: this.gender
      };
      this.people.push(person);
      this.clear();
    },
    showGender(gender) {
      return gender === 0 ? "fa-female pink" : "fa-male blue"
    }
  },
};
</script>

<style scoped>
  .pink{
    color: rgb(213, 122, 231)
  }
  .blue {
    color: rgb(66, 147, 223)
  }
</style>