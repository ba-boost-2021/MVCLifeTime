<template>
  <div> {{ $t("numbers.text", { n: number}) }}</div>
  <button class="btn btn-primary me-2 pink" @click="increase">{{ $t("numbers.increase")}}</button>
  <button class="btn btn-primary" @click="decrease" v-if="canDecrease">{{ $t("numbers.decrease") }}</button>
</template>

<script>
export default {
  name: "Number",
  props: {
      value: {
          type: Number
      }
  },
  mounted(){
      this.number = this.value ?? 0;
  },
  data() {
    return {
      number: 0,
    };
  },
  methods: {
    increase() {
      this.number++;
    },
    decrease() {
      this.number--;
    }
  },
  computed: {
    canDecrease() {
      return this.number > 0;
    }
  }
};
</script>
