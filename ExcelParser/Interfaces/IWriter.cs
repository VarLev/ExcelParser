using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParser.Interfaces
{
    public interface IWriter
    {
        string Convert<T>(T data);
        void Write<T>(IEnumerable<T> data);
    }
}
