# SPATemplate

## Intro

- Clone the repo into local respository
- Start to design for back-end : 
  + Created DataAccessLayer project, designed by SOLID architecture
  + Using third party CsvHelper.dll to extract & parse data from Csv file
  + Using AutoMapper.dll to maping data between other models.
  + Created Web API using .Net core to get data
  + Tested OK with Web API with Fiddle, PostMan tools
- Start to design for front-end : 
  + Created /clientapp directory which it reserved to Vue project  
  + Using CORS allow URL client call URL server .Net core    
  + Tested OK with features: show list customer, sorting columns, search.    
  + Configuration to integrate Vue.js into ASP.NET core  
  + Except paging feature don't implemented because error encountered. 
  + Except use Vuex for State management don't implemented because shortage experience.  
- Using Webpack to build & deployed in sucessfully on GitHub 

## Recommendations 
  Beside your UI, some non-functional requirement 
- UI for 'Search' feature: 
  + With your UI, very I feeling that it a vague when typing words to search. After searched, very difficult 
  to define are correct or wrong. 
  Solution: Design 3-4 fields are radio controls are name fields search & texbox typing to search.
  + With data in list are combined many tables & data scale out, with your UI will slow perfomence. 
  Solution: Further some combobox control with default values. When load, data will be filters by 
  all paramaters are default values.  
- UI for 'Paging' feature: 
  + List data on grid with vertical scroll not good. 
  Solution: Add Textbox control are records number for per page. when typing, it filter, show with records number per
  page screen. 

## Browser Compatibility
I has been tested on IE, Firefox and Chrome. It work fine but diffence with each browser.
  
## Time summary:
  + Research & preparation: 1 hour
  + Coding: 4 hours (including test) 
  + Styling: 1 hour (Tested & modified)
  + Building and testing : 2 hour
  
## Future plans
I plan with some features I'm considering:

- [x] Using Vuex to state management.
- [x] Grid paging or vertical scrolling.
- [ ] Add radio controls fields to filter clearly.
- [ ] Option to filter records per page .
  
## Deployment & Running 
  Get code from https://github.com/nqb19772010/SPATemplate.git and open by editor Visual Studio Code.
  + At root directory run : dotnet run
  + At /clientapp directory run : npm run dev
  
  


