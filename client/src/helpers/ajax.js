import axios from "axios";
export default {
  install: (app, options) => {
    const instance = axios.create({
      baseURL: "https://localhost:7000",
      timeout: 5000,
    });
    //HTTP HEADER buradan yönetilebilir
    app.config.globalProperties.$ajax = instance;
  },
};
