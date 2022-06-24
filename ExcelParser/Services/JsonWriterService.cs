using System;
using System.Collections.Generic;
using System.IO;
using ExcelParser.Interfaces;
using Newtonsoft.Json;


namespace ExcelParser.Services
{
    internal class JsonWriterService :IJsonWriterService
    {
        public string Convert<T>(T data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public async void Write<T>(IEnumerable<T> data)
        {
            Console.WriteLine("Введите адрес для сохранения файла");
            var path = Console.ReadLine();
            if (path is not null)
            {
                await File.WriteAllTextAsync(path, Convert(data));
            }

        }

    }
}
