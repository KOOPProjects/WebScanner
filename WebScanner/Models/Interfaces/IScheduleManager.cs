using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Interfaces
{
    public interface IScheduleManager<S,A,T> where S : IJobDetailComposer<T> where A : ITriggerComposer where T : IJob
    {
        Task AddOrder();
        void deleteOrder(int id);
    }
}
