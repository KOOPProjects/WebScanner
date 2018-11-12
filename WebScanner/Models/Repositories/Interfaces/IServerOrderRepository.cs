﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Repositories.Interfaces
{
    public interface IServerOrderRepository
    {
        IEnumerable<ServerOrder> GetServersByRequestType(string requestType);
    }
}
