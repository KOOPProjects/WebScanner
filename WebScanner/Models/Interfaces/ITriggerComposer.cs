using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Interfaces
{
    public interface ITriggerComposer
    {
        ITrigger Compose();
    }
}
