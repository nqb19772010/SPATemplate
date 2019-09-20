using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreSPATemplate
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<FieldsCsvClient, CustomerEntry>();
            CreateMap<CustomerEntry, FieldsCsvClient>();
        }
    }
    public class CustomerEntry
    {
        public string firt_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone1 { get; set; }
    }
}
