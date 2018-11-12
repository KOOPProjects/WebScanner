using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models;
using WebScanner.Models.Composers;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers;

namespace WebScanner.Examples
{
    public static class SimulateAddingOrder
    {
        public static async Task Execute()
        {
            await Task.Delay(30000);

            //initializing new provider for adding order with specific implementation of composers and job.
            var addingProvider = new AddingOrderProvider<
                ServerJobDetailComposer<ServerOrderJob>,
                SimpleTriggerComposer,
                ServerOrderJob>(
                new ServerJobDetailComposer<ServerOrderJob>(1, "172.217.16.14"),
                new SimpleTriggerComposer(5, 1)
                );

            //asynchronous adding order.
            await addingProvider.AddOrder();

            await Task.Delay(15100);

            //deleting order from schedule after delay.
            var deletingProvider = new DeletingOrderProvider();
            await deletingProvider.DeleteOrder(1);

            //adding new provider with implementations for html order
            var addingHtmlProvider = new AddingOrderProvider<
                HtmlJobDetailComposer<HtmlOrderJob>,
                SimpleTriggerComposer,
                HtmlOrderJob>(
                new HtmlJobDetailComposer<HtmlOrderJob>(2, "http://www.nordlearn.com.pl", "1"),
                new SimpleTriggerComposer(5, 2));

            //asynchronous adding order to schedule.
            await addingHtmlProvider.AddOrder();

            await Task.Delay(15100);

            //deleting order from schedule after delay.
            var deletingHtmlProvider = new DeletingOrderProvider();
            await deletingHtmlProvider.DeleteOrder(2);
        }
    }
}
