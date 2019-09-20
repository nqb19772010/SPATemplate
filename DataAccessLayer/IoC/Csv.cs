
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;

namespace DataAccessLayer
{

    /// <summary>
    /// This class Csv designed by Dependency inversion principle and 
    /// using third party: CsvHelper.dll to extract data from csv file
    /// </summary>
    public class Csv : IDatabase
    {
        string _filePath = "";

        public Csv(string filePath)
        {
            this._filePath = filePath;
        }

        public List<FieldsCsvClient> GetData()
        {
            List<FieldsCsvClient> lst = null;
            using (TextReader fileReader = File.OpenText(_filePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                csv.Read();
                lst = csv.GetRecords<FieldsCsvClient>().ToList();               
            }
            return lst;
        }

       
    }
}