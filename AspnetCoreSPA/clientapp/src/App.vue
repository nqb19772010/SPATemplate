<template>
  <div id="app">   
     <div class="panelHeading">
       <h1> Acme Contact Management </h1>
       </div>
    <div class="searchData">
      <form id="search">
        Search <input name="query" v-model="searchQuery">
      </form>
    </div>
   
    <div class="clearfix">
      <cust-list v-bind:dataCust='gridData'
        v-bind:columns='gridColumns'
        v-bind:filterKey='searchQuery'>
      </cust-list>
    </div>

    <!-- <div class="clearfix">
      <ul class="pagination">
				<li class="page-item">
					<button type="button" class="page-link" v-if="page != 1" @click="page--"> Previous </button>
				</li>
				<li class="page-item">
					<button type="button" class="page-link" v-for="pageNumber in pages.slice(page-1, page+5)" 
          v-bind:key="pageNumber"
          @click="page = pageNumber"> {{pageNumber}} </button>
				</li>
				<li class="page-item">
					<button type="button" @click="page++" v-if="page < pages.length" class="page-link"> Next </button>
				</li>
			</ul> </div>-->                    
  </div>
</template>

<script>   
  import CustList from './components/CustomerList.vue';
  export default {
    name: 'app',
    data () {
      return {
        errors: [],
        gridData: [],        
        gridColumns: ['firt_name', 'last_name','email','phone1'],
        searchQuery: '',
        /* page: 1,
        perPage: 9,
        pages: [], */
      }
    },
    
  // get data when component created successlly.
  created() {
    this.$http.get('/api/SampleData').then(res => {
      this.gridData = res.data
    })
    .catch(e => {
      this.errors.push(e)
    }) 
  },
   components: {
      CustList     
    }
  /* watch: {
        gridData () {
            this.setPages();
        }
    },
   computed: {
        filteredData () {
            return this.paginate(this.gridData);
        }
    }, */
   /* methods: {   
      getDataGrid () {
          this.$http.get('/api/SampleData').then(res => {            
                this.gridData = response.data;
            })
            .catch(response => {
                console.log(response);
            });
        },     
        setPages () {
            let numberOfPages = Math.ceil(this.gridData.length / this.perPage);
            for (let index = 1; index <= numberOfPages; index++) {
                this.pages.push(index);
            }
        },
        paginate (gridData) {
            let page = this.page;
            let perPage = this.perPage;
            let from = (page * perPage) - perPage;
            let to = (page * perPage);
            return  gridData.slice(from, to);
        },
    }, */
   /*  filters: {
      trimWords(value){
        return value.split(" ").splice(0,20).join(" ") + '...';
      }
    }, */
   
  }
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;  
}

.searchData {  
  background-color: #fff;
  margin-left: -10px;
  margin-top: 2px;
}

.panelHeading {
    background-color: #2c3e50;    
    color: #fff;
    margin-bottom: 16px;
}

.panelContact {
    background-color:#2c3e50;
   /*  border-left: 6px solid #ffeb3b;  */
    color: #fff;
    margin-top: 30px;    
    text-align: left;
}
.btn-group
{
   margin-top: 20px !important;   
   margin-left: -120px !important;   
}

button.page-link {
	display: inline-block;
}
button.page-link {
    font-size: 20px;
    color: #29b3ed;
    font-weight: 500;
}
.offset{
  width: 500px !important;
  margin: 20
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
