<template>
  <Card shadow style="height: 100%;width: 100%;">
    <Row :gutter="16">
      <Col span="7">
        <Input v-model="USD_CYN">
          <span slot="prepend">汇率</span>
        </Input>
      </Col>
      <Col span="4">
        <Button type="primary" @click="updateSettingUSD_CYN">保存</Button>
      </Col>
    </Row>
    <br>
    <Row :gutter="16">
      <Col span="7">
        <Input v-model="chinalogisticsPrice">
          <span slot="prepend">国内运费</span>
        </Input>
      </Col>
      <Col span="4">
        <Button type="primary" @click="updateSettingChinalogisticsPrice">保存</Button>
      </Col>
    </Row>
  </Card>
</template>
<script>
import {
  updateSettingChinalogisticsPrice,
  getChinalogisticsPrice,
  updateSettingUSD_CYN,
  getUSD_CYN
} from "@/api/setting";
export default {
  name: "system-setting",
  components: {},
  props: {},
  data() {
    return {
      chinalogisticsPrice: 0,
      USD_CYN:0
    };
  },
  mounted() {
    this.chinalogisticsPrice = getChinalogisticsPrice();
    this.USD_CYN=getUSD_CYN();
    console.log(this.chinalogisticsPrice);
  },
  methods: {
      updateSettingChinalogisticsPrice(){
          updateSettingChinalogisticsPrice(this.chinalogisticsPrice)
      },
      updateSettingUSD_CYN(){
          updateSettingUSD_CYN(this.USD_CYN)
      }
  }
};
</script>
