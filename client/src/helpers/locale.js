import { createI18n } from "vue-i18n";

const i18n = createI18n({
  locale: "tr",
  messages: {
    tr: {
      common: {
        save: "Kaydet",
        clear: "Temizle",
        refresh: "Yenile",
      },
      titles: {
        numbers: "Sayılar",
        employees: "Çalışanlar",
        register: "Kayıt Formu",
        order: "Sipariş",
        login: "Giriş Yap"
      },
      numbers: {
        increase: "Artır",
        decrease: "Azalt",
        text: "Sayının mevcut değeri, {n}",
      },
    },
    en: {
      common: {
        save: "Save",
        clear: "Clear",
        refresh: "Refresh",
      },
      titles: {
        numbers: "Numbers",
        employees: "Employees",
        register: "Register Form",
        order: "Order",
        login: "Login"
      },
      numbers: {
        increase: "Increase",
        decrease: "Decrease",
        text: "The current value of number is: {n}",
      },
    },
  },
});

export default i18n;
