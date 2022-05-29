import { createApp } from "vue";
import App from "./App.vue";
import i18n from "./helpers/locale";
import ajax from "./helpers/ajax";

let app = createApp(App);
app.use(i18n);
app.use(ajax);
app.mount("#app");
