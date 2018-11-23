using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.JobFactories
{
    internal sealed class IntegrationJobFactory : IJobFactory
    {
        private readonly IServiceProvider _container;

        public IntegrationJobFactory(IServiceProvider container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            var job = (IJob)_container.GetService(bundle.JobDetail.JobType);
            return job;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
