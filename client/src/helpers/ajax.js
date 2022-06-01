import axios from "axios";
export default {
  install: (app, options) => {
    const instance = axios.create({
      baseURL: "https://localhost:7000",
      timeout: 5000,
    });

    function setUpHeaders() {
      let config = {
        headers: {},
      };
      const token = localStorage.getItem("jwt");
      if (token) {
        config.headers["Authorization"] = "Bearer " + token;
      }
      return config;
    }

    let customAjax = {
      get: function (url) {
        return instance.get(url, setUpHeaders());
      },
      post: function (url, data) {
        return instance.post(url, data, setUpHeaders());
      },
    };
    app.config.globalProperties.$ajax = customAjax;
  },
};
