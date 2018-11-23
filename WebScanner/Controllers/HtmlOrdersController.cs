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
    [Route("api/htmlorders")]
    public class HtmlOrdersController : Controller
    {
        private readonly DatabaseContext _databaseContext;
       
        public HtmlOrdersController(DatabaseContext databaseContext) 
        {
            this._databaseContext = databaseContext;      
        }

        [HttpPost]
        public async Task<IActionResult> AddHtmlOrder([FromBody] HtmlOrder order)
        {
            Debug.WriteLine("Adding new order with frequency= " + order.Frequency + " , orderTarget= " + order.TargetAddress);

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
                    new HtmlJobDetailComposer<HtmlOrderJob>(order.Id, order.TargetAddress, order.SubjectOfQuestion),
                    new SimpleTriggerComposer(order.Frequency, order.Id));

            await addingHtmlProvider.AddOrder();

            return new JsonResult(order.Id);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteHtmlOrder([FromQuery] int orderId)
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
    }
}
