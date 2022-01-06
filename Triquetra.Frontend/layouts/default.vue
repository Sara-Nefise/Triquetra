<template>
  <v-app dark>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar
      :clipped-left="clipped"
      fixed
      app
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>
        <v-btn color="warning" outlined text :to="{name: 'index'}">
          {{ title }}
        </v-btn>
      </v-toolbar-title>
      <v-divider vertical class="mx-5" />
      <v-text-field
        id="search-input"
        class="mt-4"
        :maxlength="20"
        label="Aradğınız ürünü yazınız..."
        @keydown="validate"
      />
      <v-divider vertical class="mx-5" />
      <v-toolbar-title>
        <v-btn color="success" outlined text :to="{name: 'cart'}">
          SEPETİM
        </v-btn>
      </v-toolbar-title>
      <v-divider vertical class="mx-5" />
      <v-toolbar-title>gunes.sirketi@gmail.com</v-toolbar-title>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer
      :absolute="!fixed"
      app
    >
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Ana Sayfa',
          to: '/'
        },
        {
          icon: 'mdi-plus-box-multiple',
          title: 'Parça Ekle',
          to: '/products'
        },
        {
          icon: 'mdi-view-grid-plus',
          title: 'Dolar Kuru Girişi',
          to: '/add-exchange-rate'
        },
        {
          icon: 'mdi-currency-usd',
          title: 'Dolar Kurları',
          to: '/exchange-rates'
        },
        {
          icon: 'mdi-cart-outline',
          title: 'Sepet',
          to: '/cart'
        },
        {
          icon: 'mdi-playlist-check',
          title: 'Geçmiş Teklifler',
          to: '/previous-offers'
        }
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'GÜNEŞ ŞİRKETİ'
    }
  },
  mounted () {
    window.onload = () => {
      const myInput = document.getElementById('search-input')
      myInput.onpaste = e => e.preventDefault()
    }
  },
  methods: {
    validate () {
      const element = document.getElementById('search-input')
      element.value = element.value.replace(/[^a-zA-Z]+/, '')
    }
  }
}
</script>
