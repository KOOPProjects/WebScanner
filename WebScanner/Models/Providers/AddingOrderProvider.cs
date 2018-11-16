﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Interfaces;
using WebScanner.Models.JobFactories;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers.Interfaces;
using WebScanner.Models.Services;
using WebScanner.Models.Services.Interfaces;

namespace WebScanner.Models.Providers
{
    public class AddingOrderProvider<S,A,T> : IAddingOrderProvider where S : IJobDetailComposer<T> where T : IJob where A : ITriggerComposer
    {
        private readonly S jobDetailComposer;
        private readonly A triggerComposer;
      

        public AddingOrderProvider(S jobDetailComposer, A triggerComposer)
        {
            this.jobDetailComposer = jobDetailComposer;
            this.triggerComposer = triggerComposer;
          
        }

        public async Task AddOrder()
        {
            var jobDetail = jobDetailComposer.Compose();
            var trigger = triggerComposer.Compose();
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            scheduler.JobFactory = new IntegrationJobFactory(new ServiceCollectionProvider().Provide().BuildServiceProvider());
            await scheduler.Start();
            await scheduler.ScheduleJob(jobDetail, trigger);
            Debug.WriteLine("Added Job");
            
        }
    }
}
