using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Interfaces
{
    public interface IJobDetailComposer<S> where S: IJob
    {
        IJobDetail Compose();
    }
}
