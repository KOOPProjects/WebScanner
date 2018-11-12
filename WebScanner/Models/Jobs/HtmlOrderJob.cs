using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebScanner.Models.Jobs
{
    public class HtmlOrderJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

            using (WebClient client = new WebClient())
            {

                string url = context.JobDetail.JobDataMap.GetString("TargetAddress");
                string content = client.DownloadString(url);
                Debug.WriteLine(content);
            }


           

        }
    }
}
