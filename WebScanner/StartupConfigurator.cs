using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebScanner.Models.Composers;
using WebScanner.Models.Database;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers;
using WebScanner.Models.UnitOfWork;

namespace WebScanner
{
    public class StartupConfigurator : IStartupConfigurator
    {
        private readonly DatabaseContext dbContext;

        public StartupConfigurator(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Configurate()
        {
            using(UnitOfWork unitOfWork = new UnitOfWork(this.dbContext))
            {
                var htmlorders = unitOfWork.HtmlOrderRepository.GetAll();
                var serverorders = unitOfWork.ServerOrderRepository.GetAll();
                foreach(var order in htmlorders)
                {
                    var addingHtmlProvider = new AddingOrderProvider<
                        HtmlJobDetailComposer<HtmlOrderJob>,
                        SimpleTriggerComposer,
                        HtmlOrderJob>(
                            new HtmlJobDetailComposer<HtmlOrderJob>(order.Id, order.TargetAddress, order.SubjectOfQuestion),
                            new SimpleTriggerComposer(order.Frequency, order.Id));

                    await addingHtmlProvider.AddOrder();
                }
                foreach (var order in serverorders)
                {
                    var addingServerProvider = new AddingOrderProvider<
                        ServerJobDetailComposer<ServerOrderJob>,
                        SimpleTriggerComposer,
                        ServerOrderJob>(
                            new ServerJobDetailComposer<ServerOrderJob>(order.Id, order.TargetAddress),
                            new SimpleTriggerComposer(order.Frequency, order.Id));

                    await addingServerProvider.AddOrder();
                }
            }
        }
    }
}
