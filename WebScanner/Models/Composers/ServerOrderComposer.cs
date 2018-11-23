using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models.Composers
{
    public class ServerOrderComposer : IOrderComposer
    {
        private readonly string question;
        private readonly int frequency;
        private readonly string targetAddress;

        public ServerOrderComposer(int frequency, string targetAddress, string question)
        {
            this.frequency = frequency;
            this.targetAddress = targetAddress;
            this.question = question;
        }
        public IOrder Compose()
        {
            return new ServerOrder  { Frequency = this.frequency, Question = this.question, TargetAddress = this.targetAddress };
        }
    }
}
