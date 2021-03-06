using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Utility;
using Microsoft.AspNetCore.Cors;
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
       
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public List<CustomerEntry> Get()
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
