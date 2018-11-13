using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                unitOfWork.Save();
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

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteHtmlOrder([FromBody] int orderId)
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
                unitOfWork.Save();
            }

            var deletingProvider = new DeletingOrderProvider();

            await deletingProvider.DeleteOrder(orderId);

            return new JsonResult(orderId);
        }
    }
}
