using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelParser.Interfaces;
using Newtonsoft.Json.Linq;

namespace ExcelParser.Services
{
    public class PrintDataService: IPrintDataService
    {
        public void Print<T>(T data)
        {
            try
            {
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
