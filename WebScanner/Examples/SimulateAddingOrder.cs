using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models;
using WebScanner.Models.Composers;
using WebScanner.Models.Jobs;
using WebScanner.Models.Managers;

namespace WebScanner.Examples
{
    public static class SimulateAddingOrder
    {
        public static async Task Execute()
        {
            var scheduleManager = new ScheduleManager<ServerJobDetailComposer<ServerOrderJob>, SimpleTriggerComposer, ServerOrderJob>(new ServerJobDetailComposer<ServerOrderJob>(1, "172.217.16.14"), new SimpleTriggerComposer(5, 1));
            await scheduleManager.AddOrder();
        }
    }
}
