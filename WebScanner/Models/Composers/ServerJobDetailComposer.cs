using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Composers
{
    public class ServerJobDetailComposer<S> : IJobDetailComposer<S> where S : IJob
    {
        private int id;
        private string targetAddress;
        public ServerJobDetailComposer(int id, string targetAddress)
        {
            this.id = id;
            this.targetAddress = targetAddress;
        }
        public IJobDetail Compose()
        {
            return JobBuilder.Create<S>()
                    .WithIdentity(JobKey.Create(this.id.ToString()))
                    .UsingJobData("TargetAddress", targetAddress)
                    .UsingJobData("Id", id)
                    .Build();
        }
    }
}
