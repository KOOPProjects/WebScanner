using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Services;
using WebScanner.Models.Services.Interfaces;

namespace WebScanner.Models.Jobs
{
    public class HtmlOrderJob : IJob
    {
        private readonly ResponseService responseService;

        public HtmlOrderJob(ResponseService responseService)
        {
            this.responseService = responseService;
        }
      
     
        public async Task Execute(IJobExecutionContext context)
        {
          

            using (WebClient client = new WebClient())
            {
                var response = new Response();
                response.Date = DateTime.Now;
                response.OrderId = context.JobDetail.JobDataMap.GetInt("Id");
                string url = context.JobDetail.JobDataMap.GetString("TargetAddress");
                string content = client.DownloadString(url);
                if (content.Contains(context.JobDetail.JobDataMap.GetString("Content")))
                {
                    response.Content = "{" + Environment.NewLine + "\"Status\":" + "\"Not changed\"";
                }
                else
                {
                    response.Content = "{" + Environment.NewLine + "\"Status\":" + "\"Changed\"";
                }
                    Debug.WriteLine(response.Content);
                    await responseService.AddResponseToDb(response);
             
                
                
                
            }


           

        }
    }
}
