<template>
  <v-container>
    <div v-if="step === 0">
      <v-row>
        <v-col>
          <v-btn
            small
            text
            color="primary"
            tile
            outlined
          >
            İnvertör Seçiniz
          </v-btn>
        </v-col>
        <v-spacer />
        <v-col>
          <CurrentDate />
        </v-col>
      </v-row>
      <v-row>
        <v-col v-for="inverter in inverters" :key="inverter.name" cols="2">
          <v-card max-width="175px">
            <v-card-text>
              {{ inverter.name }}  <v-btn small fab icon color="success" @click="updateCart(inverter)">
                <v-icon>
                  mdi-plus
                </v-icon>
              </v-btn> <br>
              {{ inverter.dollarPrice }}$
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn
            small
            text
            color="primary"
            tile
            outlined
          >
            Panel Seçiniz
          </v-btn>
        </v-col>
        <v-spacer />
      </v-row>
      <v-row>
        <v-col v-for="panel in panels" :key="panel.name" cols="2">
          <v-card max-width="175px">
            <v-card-text>
              {{ panel.name }}  <v-btn small fab icon color="success" @click="updateCart(panel)">
                <v-icon>
                  mdi-plus
                </v-icon>
              </v-btn> <br>
              {{ panel.dollarPrice }}$ <br>
              {{ panel.size }} metrekare
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
      <v-row class="mt-5">
        <v-col />
        <v-col />
        <v-col>
          <v-btn color="red darken-1" @click="deleteCart()">
            Sepeti Sıfırla
            <v-icon
              right
              dark
            >
              mdi-delete
            </v-icon>
          </v-btn>
        </v-col>
      </v-row>
      <v-row>
        <v-col />
        <v-col />
        <v-col>
          <v-btn color="green darken-1" @click="nextStep()">
            Sepete Eklemeyi Tamamla
            <v-icon
              right
              dark
            >
              mdi-arrow-right
            </v-icon>
          </v-btn>
        </v-col>
      </v-row>
      <v-row v-if="cart.length > 0" class="mt-5">
        <v-col>
          <v-card>
            <v-card-title>SEPET</v-card-title>
            <v-card-text>
              {{ cart.map(function (s) {
                return s.name
              }).join(", ") }}
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </div>
    <div v-else-if="step===1">
      <v-row>
        <v-col cols="6">
          <v-card>
            <v-card-title>GÜNEŞ ŞİRKETİNİN HAZIRLADIĞI TEKLİF</v-card-title>
            <v-card-text>
              <v-simple-table dark>
                <template #default>
                  <thead>
                    <tr>
                      <th>
                        MARKA
                      </th>
                      <th>
                        ADET
                      </th>
                      <th>
                        TUTAR
                      </th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="item in groupedCart"
                      :key="item.key"
                    >
                      <td class="text-left">
                        {{ item.key }}
                      </td>
                      <td class="text-left">
                        {{ item.values.length }}
                      </td>
                      <td class="text-left">
                        {{ itemTotalPrice(item.values) }} TL
                      </td>
                    </tr>
                  </tbody>
                </template>
              </v-simple-table>
            </v-card-text>
          </v-card>
        </v-col>
        <v-spacer />
        <v-col>
          <CurrentDate />
        </v-col>
      </v-row>
      <v-row class="mt-5">
        <v-col />
        <v-col />
        <v-col>
          <v-btn color="red darken-1" @click="previousStep()">
            <v-icon
              left
              dark
            >
              mdi-arrow-left
            </v-icon>
            Geri Dön
          </v-btn>
        </v-col>
      </v-row>
      <v-row>
        <v-col />
        <v-col />
        <v-col>
          <v-btn color="green darken-1" @click="nextStep()">
            Teklif Sonucunu Gör
            <v-icon
              right
              dark
            >
              mdi-arrow-right
            </v-icon>
          </v-btn>
        </v-col>
      </v-row>
    </div>
    <div v-else-if="step === 2">
      <v-row>
        <v-col>
          <v-card v-if="offer.totalPriceTL > 0">
            <v-card-title>
              TEKLİF SONUCU
            </v-card-title>
            <v-card-text>
              <v-row>
                <v-col cols="9">
                  SİSTEMİN KURULACAĞI ALAN BOYUTU <br>
                  İNVERTÖR ADEDİ <br>
                  PANEL ADEDİ <br>
                  TOPLAM FİYAT
                </v-col>
                <v-col cols="3">
                  {{ offer.setupArea }} metrekare <br>
                  {{ offer.inverterCount }} <br>
                  {{ offer.panelCount }} <br>
                  {{ offer.totalPriceTL.toFixed(2) }} TL
                </v-col>
              </v-row>
            </v-card-text>
          </v-card>
        </v-col>
        <v-spacer />
        <v-col>
          <CurrentDate />
        </v-col>
      </v-row>
      <v-row>
        <v-col style="text-align: center" cols="3">
          <v-alert type="info" outlined dense>
            İSKONTO ORANI <br>GİRİNİZ.
          </v-alert>
        </v-col>
        <v-col align-self="center" cols="2">
          <v-text-field
            v-model="offer.discountRate"
            hide-details
            label="İskonto Oranı (%)"
            type="number"
            dense
            outlined
          />
        </v-col>
        <v-col cols="3" align-self="center">
          <v-btn color="primary" outlined @click="addDiscount">
            Kaydet
          </v-btn>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-alert max-width="300px" type="success" v-if="offer.discountedPriceTL > 0">İNDİRİMLİ FİYAT: {{ offer.discountedPriceTL.toFixed(2) }} TL</v-alert>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import apiservice from '~/services/apiservice'

export default {
  name: 'Cart',
  data () {
    return {
      inverters: [],
      panels: [],
      cart: [],
      groupedCart: [],
      step: 0,
      exchangeRates: [],
      lastExchangeRate: 0,
      offer: {},
      offerId: 0,
      model: {}
    }
  },
  computed: {

  },
  mounted () {
    this.getProducts()
    this.getExchangeRates()
  },
  methods: {
    getProducts () {
      apiservice.get('api/Product').then((data) => {
        this.inverters = data.data.filter(s => s.productTypeId === 1)
        this.panels = data.data.filter(s => s.productTypeId === 2)
      }).catch(() => {
      })
    },
    updateCart (item) {
      this.cart.push(item)
    },
    deleteCart () {
      this.cart = []
    },
    nextStep () {
      if (this.step === 0) {
        this.groupedCart = this.groupByArray(this.cart, 'name')
      } else if (this.step === 1) {
        this.saveOffer()
      }
      this.step += 1
    },
    previousStep () { this.step -= 1 },
    groupByArray (xs, key) {
      return xs.reduce(function (rv, x) {
        const v = key instanceof Function ? key(x) : x[key]
        const el = rv.find(r => r && r.key === v)
        if (el) {
          el.values.push(x)
        } else {
          rv.push({ key: v, values: [x] })
        }
        return rv
      }, [])
    },
    getExchangeRates () {
      apiservice.get('api/ExchangeRate').then((data) => {
        this.exchangeRates = data.data
        this.lastExchangeRate = this.exchangeRates[0].amount
      }).catch(() => {
      })
    },
    itemTotalPrice (values) {
      let total = 0
      for (let i = 0; i < values.length; i++) {
        total += values[i].dollarPrice * this.lastExchangeRate
      }
      return total.toFixed(2)
    },
    saveOffer () {
      this.model = {
        SetupArea: 0,
        PanelCount: 0,
        InverterCount: 0,
        TotalPriceDollar: 0,
        TotalPriceTL: 0
      }
      for (let i = 0; i < this.cart.length; i++) {
        const item = this.cart[i]
        if (item.productTypeId === 2) {
          this.model.SetupArea += item.size
          this.model.PanelCount += 1
        } else if (item.productTypeId === 1) {
          this.model.InverterCount += 1
        }
        this.model.TotalPriceDollar += item.dollarPrice
        this.model.TotalPriceTL += item.dollarPrice * this.lastExchangeRate
      }
      apiservice.post('api/Offer', this.model).then((data) => {
        this.getOffer(data.data)
        this.offerId = data.data
      }).catch((ex) => {
        console.log(ex)
      })
    },
    getOffer (id) {
      apiservice.get('api/Offer/' + id).then((data) => {
        this.offer = data.data
      }).catch(() => {
      })
    },
    addDiscount () {
      this.model.Id = this.offerId
      if (this.offer.discountRate > 20) {
        alert("İskonto %20'den fazla olamaz")
        return
      }
      this.model.DiscountRate = this.offer.discountRate
      apiservice.post('api/Offer', this.model).then((data) => {
        this.getOffer(this.offerId)
        alert('Kaydedildi')
      }).catch(() => {
      })
    }
  }

}
</script>
