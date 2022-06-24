using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelParser.Interfaces;
using ExcelParser.Model;
using ExcelParser.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ExcelParser
{
    internal class Program
    {
        public static IConfiguration configuration;
        public static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .CreateLogger();
            try
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                serviceProvider = serviceCollection.BuildServiceProvider();
                ReadData();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
            }
        }

        private static void ReadData()
        {
            var excelReaderService = serviceProvider.GetService<IExcelReaderService>();
            var jsonWriterService = serviceProvider.GetService<IJsonWriterService>();
            var csvWriterService = serviceProvider.GetService<ICsvWriterService>();
            var printDataService = serviceProvider.GetService<IPrintDataService>();
            
            Console.WriteLine("Введите адрес Excel файла для импорта");
            var pathtoExcel = Console.ReadLine();
            if (pathtoExcel != null)
            {
                var filteredDataList = excelReaderService?
                    .ReadAsync<Fine>(pathtoExcel).Result
                    .Where(x => x.Profit > 1000).ToList();
                var jsonData = jsonWriterService.Convert(filteredDataList);
                printDataService.Print(jsonData);

                Console.WriteLine("Введите формат для сохранения (json/csv)");
                var format = Console.ReadLine();
                if (format == "json")
                {
                    jsonWriterService.Write(filteredDataList);
                }
                else if (format == "csv")
                {
                    csvWriterService.Write(filteredDataList);
                }
            }
        }


        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .Build();
            serviceCollection.AddScoped<IExcelReaderService, ExcelReaderService>();
            serviceCollection.AddScoped<IJsonWriterService, JsonWriterService>();
            serviceCollection.AddScoped<ICsvWriterService, CsvWriterService>();
            serviceCollection.AddScoped<IPrintDataService, PrintDataService>();
        }
    }
}