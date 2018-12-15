using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using WebScanner.Models.Providers.Interfaces;

namespace WebScanner.Models.Providers
{
    public class DeletingOrderProvider : IDeletingOrderProvider
    {
        public async Task DeleteOrder(int id)
        {
            NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();
            bool a = await scheduler.DeleteJob(JobKey.Create(id.ToString()));
            Debug.WriteLine("Deleted Job...." + a);
        }
    }
}
