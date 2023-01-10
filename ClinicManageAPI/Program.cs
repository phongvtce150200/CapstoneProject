using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;

namespace ClinicManageAPI
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true).Build();

        [Obsolete]
        public static void Main(string[] args)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");


            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn("UserName",System.Data.SqlDbType.VarChar),
                    new SqlColumn("UserId",System.Data.SqlDbType.VarChar)
                }
            };
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.MSSqlServer(connectionString,
                sinkOptions: new SinkOptions { TableName = "Logs" },
                null, null, LogEventLevel.Information, null, columnOptions: columnOptions, null, null).CreateLogger();



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
