﻿using Quartz;
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
                OrderId = context.JobDetail.JobDataMap.GetInt("Id"),
                Type = "server"
            };

            try
            {
                var ping = new Ping();
                var pingReply = await ping.SendPingAsync(context.JobDetail.JobDataMap.GetString("TargetAddress"));
                response.Content = "{" + System.Environment.NewLine + "\"Status\": " + "\"" + pingReply.Status.ToString() + "\"" + "," + System.Environment.NewLine + "\"Latency\": " + pingReply.RoundtripTime.ToString() + Environment.NewLine + "}";
            }
            catch(PingException e)
            {
                response.Content = "{" + System.Environment.NewLine + "\"Status\": " + "\"" + "Failure" + "\"" + "," + System.Environment.NewLine + "\"Latency\": " + "0" + Environment.NewLine + "}";
            }
            finally
            {
                Debug.WriteLine(response.Content);
                await responseService.AddResponseToDb(response);
            }
        }
    }
}
