using System;
using System.Collections.Generic;

namespace DataAccessLayer
{

    /// <summary>
    /// DatabaseManager designed by SOLID architecture principles. 
    /// It used principles : Single responsibility principle & Dependency inversion principle 
    /// and ensure that scale out system
    /// </summary>
    public class DatabaseManager 
    {       
        private IDatabase iData;

        public void getDataAcessType(IDatabase typeData)
        {
            this.iData = typeData;
        }

        public List<FieldsCsvClient> GetData()
        {
            List<FieldsCsvClient> lst = null;
            lst = this.iData.GetData();
            return lst;
        }
    }
}