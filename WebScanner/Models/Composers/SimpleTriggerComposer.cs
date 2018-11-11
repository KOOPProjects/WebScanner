using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Composers
{
    public class SimpleTriggerComposer : ITriggerComposer
    {
        private int intervalInSeconds;
        private int id;
        public SimpleTriggerComposer(int intervalInSeconds, int id)
        {
            this.intervalInSeconds = intervalInSeconds;
            this.id = id;
        }
        public ITrigger Compose()
        {
            return TriggerBuilder.Create()
                .WithIdentity(this.id.ToString())
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(this.intervalInSeconds).RepeatForever())
                .Build();
        }
    }
}
