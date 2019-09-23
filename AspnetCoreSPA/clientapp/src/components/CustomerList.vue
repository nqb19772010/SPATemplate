<template type="text/x-template" id="grid-template">
     <table>
   <thead>
       <tr>
        <td class="panelContact" colspan="4">            
          <strong> Contact List </strong>    
        </td>   
       </tr>
      <tr>
        <th v-for="key in columns" v-bind:key="key"
          @click="sortBy(key)"
          :class="{ active: sortKey == key }">
          <div class="col-header" v-if="key === 'firt_name'"> First </div>
             <div class="col-header" v-else-if="key === 'last_name'" > Last </div> 
             <div class="col-header" v-else-if="key === 'email'"> Email </div> 
             <div class="col-header" v-else-if="key === 'phone1'"> Phone 1 </div>                            
          <span class="arrow" :class="sortOrders[key] > 0 ? 'asc' : 'dsc'">
          </span>
        </th>
      </tr>
    </thead> 
    <tbody>   
       <tr v-for="key in filteredData" v-bind:key="key.email">
        <td>
          {{key.firt_name}} 
        </td>
        <td>
          {{key.last_name}} 
        </td>
        <td>
          {{key.email}} 
        </td>
        <td>
          {{key.phone1}} 
        </td>
      </tr> 
    </tbody>
  </table>
  
</template>

<script>
export default {
  name:'customer-list',
  template: '#grid-template',
  props: {
    dataCust: Array,
    columns: Array,
    filterKey: String
  },
  data: function () {
    var sortOrders = {}
    this.columns.forEach(function (key) {
      sortOrders[key] = 1
    })
    return {
      sortKey: '',
      sortOrders: sortOrders
    }
  },
  computed: {
    filteredData: function () {
      var sortKey = this.sortKey
      var filterKey = this.filterKey && this.filterKey.toLowerCase()
      var order = this.sortOrders[sortKey] || 1
      var dataCust = this.dataCust
      if (filterKey) {
        dataCust = dataCust.filter(function (row) {
          return Object.keys(row).some(function (key) {
            return String(row[key]).toLowerCase().indexOf(filterKey) > -1
          })
        })
      }
      if (sortKey) {
        dataCust = dataCust.slice().sort(function (a, b) {
          a = a[sortKey]
          b = b[sortKey]
          return (a === b ? 0 : a > b ? 1 : -1) * order
        })
      }
      return dataCust
    }
  },
  filters: {
    capitalize: function (str) {
      return str.charAt(0).toUpperCase() + str.slice(1)
    }
  },
  methods: {
    sortBy: function (key) {
      this.sortKey = key
      this.sortOrders[key] = this.sortOrders[key] * -1
    }
  }
}


</script>
<style>
body {
  font-family: Helvetica Neue, Arial, sans-serif;
  font-size: 14px;
  color: #444;
}

table {
  border: 2px solid #CC092F;
  border-radius: 3px;
  background-color: #fff;
  margin-left: 250px;
  margin-top: 10px;
}

th {
  background-color: #CC092F;
  color: rgba(255,255,255,0.66);
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

.col-header {
  float: left;
  font-weight: bold;
  color: WHITE;
}

td {
  background-color: #f9f9f9;
}

th, td {
  min-width: 120px;
  padding: 10px 20px;
  text-align: left;
}

th.active {
  color: #fff;
}

th.active .arrow {
  opacity: 1;
}

.arrow {
  display: inline-block;
  vertical-align: middle;
  width: 0;
  height: 0;
  margin-left: 5px;
  opacity: 0.66;
}

.arrow.asc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-bottom: 4px solid #fff;
}

.arrow.dsc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-top: 4px solid #fff;
}

</style>