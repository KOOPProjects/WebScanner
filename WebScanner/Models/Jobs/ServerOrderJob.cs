using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace WebScanner.Models.Jobs
{
    public class ServerOrderJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var ping = new Ping();
            var pingReply = ping.Send(context.JobDetail.JobDataMap.GetString("TargetAddress"));
            Debug.WriteLine("Pinging " + pingReply.Address.ToString() + " -status: " + pingReply.Status.ToString());
        }
    }
}
