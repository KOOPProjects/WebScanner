using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Composers
{
    public class HtmlJobDetailComposer<S> : IJobDetailComposer<S> where S : IJob
    {
        private int id;
        private string targetAddress;
        private string content;
        public HtmlJobDetailComposer(int id, string targetAddress, string content)
        {
            this.id = id;
            this.targetAddress = targetAddress;
            this.content = content;
        }

        public IJobDetail Compose()
        {
            return JobBuilder.Create<S>()
                    .WithIdentity(this.id.ToString())
                    .UsingJobData("TargetAddress", targetAddress)
                    .UsingJobData("Content", content)
                    .UsingJobData("Id", id)
                    .Build();
        }
    }
}
