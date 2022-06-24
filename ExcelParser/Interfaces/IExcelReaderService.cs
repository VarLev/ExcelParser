using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParser.Interfaces
{
    public interface IExcelReaderService
    {
        Task<IEnumerable<T>> ReadAsync<T>(string path);
    }
}
