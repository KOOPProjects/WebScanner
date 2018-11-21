using Quartz;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using WebScanner.Models.Services;

namespace WebScanner.Models.Jobs
{
    public class ServerOrderJob : IJob
    {
        private readonly ResponseService responseService;

        public ServerOrderJob(ResponseService responseService)
        {
            this.responseService = responseService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var response = new Response
            {
                Date = DateTime.Now,
                OrderId = context.JobDetail.JobDataMap.GetInt("Id")
            };
            var ping = new Ping();
            var pingReply = ping.Send(context.JobDetail.JobDataMap.GetString("TargetAddress"));
            response.Content = "{" + System.Environment.NewLine + "\"status\": " + "\"" + pingReply.Status.ToString() + "\"" + "," + System.Environment.NewLine + "\"latency\": " + pingReply.RoundtripTime.ToString() + Environment.NewLine + "}";
            Debug.WriteLine(response.Content);
            await responseService.AddResponseToDb(response);
        }
    }
}
