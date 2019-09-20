using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;


namespace AspnetCoreSPATemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {
        // Create a field to store the mapper object
        private readonly IMapper _mapper;
        private IHostingEnvironment _hostingEnvironment;

        public SampleDataController(IHostingEnvironment environment, IMapper mapper)
        {
            this._hostingEnvironment = environment;
            this._mapper = mapper;
        }
        //private static string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //[HttpGet("[action]")]
        //public IEnumerable<WeatherForecast> WeatherForecasts()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}

        //public class WeatherForecast
        //{
        //    public string DateFormatted { get; set; }
        //    public int TemperatureC { get; set; }
        //    public string Summary { get; set; }

        //    public int TemperatureF
        //    {
        //        get
        //        {
        //            return 32 + (int)(TemperatureC / 0.5556);
        //        }
        //    }
        //}
        [HttpGet]
        public List<CustomerEntry> Get() //DataParserCsv
        {
            List<CustomerEntry> lstCust = new List<CustomerEntry>();
            string pathToFile = Path.Combine(_hostingEnvironment.ContentRootPath, "SampleData.csv");
            if (UtilityHelper.CheckFileExist(pathToFile, "SampleData.csv"))
            {
                IDatabase csvObj = new DataAccessLayer.Csv(pathToFile);
                DatabaseManager dbManager = new DatabaseManager();
                dbManager.getDataAcessType(csvObj);
                lstCust = _mapper.Map<List<CustomerEntry>>(dbManager.GetData());
            }
            else
            {                
                throw new FileNotFoundException("File invalid!!");
            }
            return lstCust;
        }

    }
}
