using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Managers
{
    public class ScheduleManager<S,A,T> : IScheduleManager<S, A, T> where S : IJobDetailComposer<T> where A : ITriggerComposer where T : IJob
    {
        private readonly S jobDetailComposer;
        private readonly A triggerComposer;

        public ScheduleManager(S jobDetailComposer, A triggerComposer)
        {
            this.jobDetailComposer = jobDetailComposer;
            this.triggerComposer = triggerComposer;
            
        }

        public async Task AddOrder()
        {
            var jobDetail = jobDetailComposer.Compose();
            var trigger = triggerComposer.Compose();
            NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            await scheduler.ScheduleJob(jobDetail, trigger);
        }

        public void deleteOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
