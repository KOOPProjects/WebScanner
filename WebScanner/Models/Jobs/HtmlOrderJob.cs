using Quartz;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WebScanner.Models.Services;

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
            var response = new Response
            {
                Date = DateTime.Now,
                OrderId = context.JobDetail.JobDataMap.GetInt("Id"),
                Type = "html"
            };
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = context.JobDetail.JobDataMap.GetString("TargetAddress");
                    string content = await client.DownloadStringTaskAsync(url);
                    if (content.Contains(context.JobDetail.JobDataMap.GetString("Content")))
                    {
                        response.Content = "{" + Environment.NewLine + "\"Status\":" + "\"Not changed\"" + Environment.NewLine + "}";
                    }
                    else
                    {
                        response.Content = "{" + Environment.NewLine + "\"Status\":" + "\"Changed\"" + Environment.NewLine + "}";
                    }
                }
            }
            catch(WebException e)
            {
                response.Content = "{" + Environment.NewLine + "\"Status\":" + "\"Failure\"" + Environment.NewLine + "}";
            }
            finally
            {
                Debug.WriteLine(response.Content);
                await responseService.AddResponseToDb(response);
            }
        }
    }
}
