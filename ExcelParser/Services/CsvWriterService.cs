using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using ExcelParser.Interfaces;

namespace ExcelParser.Services
{
    public class CsvWriterService : ICsvWriterService
    {
        public string Convert<T>(T data)
        {
            throw new NotImplementedException();
        }

        public async void Write<T>(IEnumerable<T> data)
        {
            Console.WriteLine("Введите адрес для сохранения файла");
            var path = Console.ReadLine();
            if (path != null)
            {
                var lines = new List<string>();
                IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
                var header = string.Join(",", props.ToList().Select(x => x.Name));
                lines.Add(header);
                var valueLines = data.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
                lines.AddRange(valueLines);
                await File.WriteAllLinesAsync(path, lines.ToArray());
            }

        }
    }
}
