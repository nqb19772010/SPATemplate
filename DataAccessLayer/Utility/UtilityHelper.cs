using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataAccessLayer.Utility
{
    public static class UtilityHelper
    {
        public static List<T> ToNonNullList<T>(this IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }
        
        public static bool CheckFileExist(string curFile, string fileName)
        {
            bool result = false;
            result = File.Exists(curFile);
            if (result)
            {                
                FileInfo fi = new FileInfo(fileName);
                string ext = fi.Extension;
                if (ext != ".csv") result = false;
            }
            return result;
        }
    }



}
