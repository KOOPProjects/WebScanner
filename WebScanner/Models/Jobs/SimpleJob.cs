using Quartz;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebScanner.Models.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("witam");
        }
    }
}
