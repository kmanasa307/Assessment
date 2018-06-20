using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Assessment.Web;
using Assessment.Web.Models;

namespace Assessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeData();

            CreateWebHostBuilder(args).Build().Run();
        }

        private static void InitializeData()
        {
            var boards = new List<Board>
            {
                new Board{ Id = 1, CreatedAt = DateTime.Now.AddDays(-7), Name = "Board #1" },
                new Board{ Id = 2, CreatedAt = DateTime.Now.AddDays(-2), Name = "Board #2" },
                new Board{ Id = 3, CreatedAt = DateTime.Now.AddDays(-1), Name = "Board #3" }
            };

            var json = JsonConvert.SerializeObject(boards);

            var filePath = Application.Configuration["DataFile"];
            if (!Path.IsPathRooted(filePath)) filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            if (File.Exists(filePath)) File.Delete(filePath);
            File.WriteAllText(filePath, json);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
