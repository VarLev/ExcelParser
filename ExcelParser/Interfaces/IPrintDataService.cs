using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParser.Interfaces
{
    public interface IPrintDataService
    {
        void Print<T>(T data);
    }
}
