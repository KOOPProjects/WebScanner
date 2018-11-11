using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Composers
{
    public class JobDetailComposer<S> : IJobDetailComposer<S> where S : IJob
    {
        private int id;
        public JobDetailComposer(int id)
        {
            this.id = id;
        }

            

        public IJobDetail Compose()
        {
            return JobBuilder.Create<S>()
                    .WithIdentity(this.id.ToString())
                    .Build();
        }
    }
}
