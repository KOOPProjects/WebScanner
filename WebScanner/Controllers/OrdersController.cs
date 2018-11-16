using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebScanner.Models;
using WebScanner.Models.Composers;
using WebScanner.Models.Database;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers;
using WebScanner.Models.UnitOfWork;

namespace WebScanner.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private DatabaseContext _databaseContext;
       

        public OrdersController(DatabaseContext databaseContext) 
        {
            this._databaseContext = databaseContext;
         
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddHtmlOrder([FromBody] HtmlOrder order)
        {
            Debug.WriteLine("Adding new order with frequency= " + order.Frequency + " , orderTarget= " + order.TargetAdress);

            if (!ModelState.IsValid)
            {
                return BadRequest("Request body is not correct!");
            }

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.HtmlOrderRepository.Add(order);
                await unitOfWork.Save();
            }

            var addingHtmlProvider = new AddingOrderProvider<
                HtmlJobDetailComposer<HtmlOrderJob>,
                SimpleTriggerComposer,
                HtmlOrderJob>(
                    new HtmlJobDetailComposer<HtmlOrderJob>(order.Id, order.TargetAdress, order.SubjectOfQuestion),
                    new SimpleTriggerComposer(order.Frequency, order.Id));

            await addingHtmlProvider.AddOrder();

            return new JsonResult(order.Id);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteHtmlOrder(int orderId)
        {
            Debug.WriteLine("Deleting order with id= " + orderId);

            if (!ModelState.IsValid)
            {
                return BadRequest("Request body is not correct!");
            }

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                if (unitOfWork.HtmlOrderRepository.Get(orderId) == null)
                {
                    return BadRequest("Order not exist!");
                }
                unitOfWork.HtmlOrderRepository.Remove(unitOfWork.HtmlOrderRepository.Get(orderId));
                await unitOfWork.Save();
            }

            var deletingProvider = new DeletingOrderProvider();

            await deletingProvider.DeleteOrder(orderId);

            return new JsonResult(orderId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddServerOrder([FromBody] ServerOrder order)
        {
            Debug.WriteLine("Adding new order with frequency= " + order.Frequency + " , orderTarget= " + order.TargetAdress);

            if (!ModelState.IsValid)
            {
                return BadRequest("Request body is not correct!");
            }

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.ServerOrderRepository.Add(order);
                await unitOfWork.Save();
            }

            var addingServerProvider = new AddingOrderProvider<
                ServerJobDetailComposer<ServerOrderJob>,
                SimpleTriggerComposer,
                ServerOrderJob>(
                    new ServerJobDetailComposer<ServerOrderJob>(order.Id, order.TargetAdress),
                    new SimpleTriggerComposer(order.Frequency, order.Id));

            await addingServerProvider.AddOrder();

            return new JsonResult(order.Id);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteServerOrder(int orderId)
        {
            Debug.WriteLine("Deleting order with id= " + orderId);

            if (!ModelState.IsValid)
            {
                return BadRequest("Request body is not correct!");
            }

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                if (unitOfWork.ServerOrderRepository.Get(orderId) == null)
                {
                    return BadRequest("Order not exist!");
                }
                unitOfWork.ServerOrderRepository.Remove(unitOfWork.ServerOrderRepository.Get(orderId));
                await unitOfWork.Save();
            }

            var deletingProvider = new DeletingOrderProvider();

            await deletingProvider.DeleteOrder(orderId);

            return new JsonResult(orderId);
        }
    }
}
