<template>
  <div class="wrapper">
    <div class="wrapper-head">HEAD</div>
    <div class="wrapper-container">

      <!-- ITEMS -->
      <div class="wrapper-container-item" v-for="(item, index) in items">
        <div class="wrapper-container-item-left">
          <div class="icon">
            <i class="fa fa-briefcase"></i>
          </div>
          <div class="time">{{item.date.time}} pm</div>
          <div class="hour">{{item.date.hour_ago}} hour ago</div>
        </div>
        <div class="wrapper-container-item-right">
          <p class="title">{{item.title}}</p>
          <div class="message">
            {{item.text}}
          </div>
        </div>
      </div>
    </div>

    <!-- test form -->
    <div class="wrapper-form">
      <p>
        <input type="text" placeholder="Title" v-model="axiosData.title" />
      </p>
      <p>
        <textarea placeholder="Text" v-model="axiosData.text" />
      </p>
      <p>
        <input type="button" value="Send" @click="addItem()" />
      </p>
    </div>
  </div>
</template>


<script>
import axios from 'axios';
export default {
  name: "home",
  components: {

  },
  data() {
    return {
      connection: '',
      items: {},
      axiosData: {}
    };
  },
  computed: {

  },
  methods: {
    update() {
      var self = this;
      this.connection.on("Update", function(response) {
        self.items.unshift(response);
      });
    },
    addItem() {
      this.connection
        .invoke("Update", this.axiosData)
        .catch(function(err) {
          return console.error(err.toSting());
        });
    }
  },
  created() {
    axios.get('/get-items').then(response => {
      this.items = response.data;
    })



    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/new-item")
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.connection.start().catch(function(err) {
      return console.error(err.toSting());
    });


  },
  mounted() {
    this.update();
  },
  watch: {
    updateList() {
      this.items;
    }
  }
};
</script>

<style lang="scss">
body,
html {
  margin: 0;
  min-height: 100%;
  background: #F3F3F4;
  color: #676a6c;
  font-size: 13px;
  font-family: "open sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
}

.fa-briefcase:before {
  content: "\f0b1";
}

.wrapper {
  max-width: 90%;
  margin: auto;
  background: #fff;
  border: 1px solid #E7EAEC;
  margin-top: 20px;
  &-head {
    padding: 15px 10px;
    border-bottom: 1px solid #E7EAEC;
  }
  &-container {
    padding: 15px;
    &-item {
      display: flex;
      &-left {
        padding: 15px;
        width: 25%;
        text-align: right;
        border-right: 1px solid #E7EAEC;
        position: relative;
        .icon {
          position: absolute;
          right: 0;
          top: 0;
        }
        .time {
          margin: 5px 0;
        }
        .hour {
          color: #1ab394;
          font-size: 80%;
          font-weight: 400;
        }
      }
      &-right {
        padding: 15px;
        max-width: 58.333333%;
        border-bottom: 1px solid #E7EAEC;
        .title {
          margin-top: 0;
          font-weight: bold;
        }
      }
    }
  }
}
</style>
