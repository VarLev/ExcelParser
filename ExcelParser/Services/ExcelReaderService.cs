using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelParser.Interfaces;
using Ganss.Excel;
using NPOI.Util;


namespace ExcelParser.Services
{
    public class ExcelReaderService: IExcelReaderService
    {
        public async Task<IEnumerable<T>>? ReadAsync<T>(string path)
        {
            if (File.Exists(path))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    if (stream.Length < Int32.MaxValue)
                    {
                        var excel = new ExcelMapper();
                        excel.NormalizeUsing(x => x.Trim());
                        return (await excel.FetchAsync<T>(stream,0)).ToList();
                    }

                    throw new Exception("Файл слишком большой");
                }
            }

            return null;
        }
    }
}
