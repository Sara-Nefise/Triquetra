<template>
  <v-container>
    <v-row>
      <v-col cols="10" class="text-center">
        <v-simple-table dark>
          <template #default>
            <thead>
              <tr>
                <th class="text-center">
                  KURULUM ALANI
                </th>
                <th class="text-center">
                  İNVERTÖR SAYISI
                </th>
                <th class="text-center">
                  PANEL SAYISI
                </th>
                <th class="text-center">
                  TOPLAM FİYAT (TL)
                </th>
                <th class="text-center">
                  TOPLAM FİYAT (DOLAR)
                </th>
                <th class="text-center">
                  İSKONTO ORANI
                </th>
                <th class="text-center">
                  İNDİRİMLİ FİYAT (TL)
                </th>
                <th class="text-center">
                  TARİH
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="item in offers"
                :key="item.addedOn"
              >
                <td>
                  {{ item.setupArea }}
                </td>
                <td>
                  {{ item.inverterCount }}
                </td>
                <td>
                  {{ item.panelCount }}
                </td>
                <td>
                  {{ item.totalPriceTL }}
                </td>
                <td>
                  {{ item.totalPriceDollar }}
                </td>
                <td v-if="item.discountRate > 0">
                  {{ item.discountRate }}
                </td>
                <td v-else>
                  -
                </td>
                <td v-if="item.discountedPriceTL">
                  {{ item.discountedPriceTL }}
                </td>
                <td v-else>
                  -
                </td>
                <td>
                  {{ $moment(item.addedOn).locale("tr").format("DD/MM/YYYY") }}
                </td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-col>
      <v-col cols="2">
        <CurrentDate />
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import apiservice from '~/services/apiservice'

export default {
  data () {
    return {
      offers: []
    }
  },
  mounted () {
    this.getPreviousOffers()
  },
  methods: {
    getPreviousOffers () {
      apiservice.get('api/Offer').then((data) => {
        this.offers = data.data
      }).catch(() => {
      })
    }
  }
}
</script>
