using Microsoft.AspNetCore.Mvc;
using WebScanner.Models;
using WebScanner.Models.Composers;
using WebScanner.Models.Database;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers;
using WebScanner.Models.UnitOfWork;

namespace WebScanner.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private DatabaseContext _databaseContext;

        public OrdersController(DatabaseContext databaseContext) 
        {
            this._databaseContext = databaseContext;
        }

        [HttpPost("Action")]
        public IActionResult AddHtmlOrder(HtmlOrder order)
        {
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

            addingHtmlProvider.AddOrder();

            return new JsonResult(order.Id);
        }

        [HttpPost("Action")]
        public IActionResult AddServerOrder(ServerOrder order)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.ServerOrderRepository.Add(order);
                unitOfWork.Save();
            }

            return new JsonResult("dupa");
        }

        [HttpPost("Action")]
        public IActionResult DeleteHtmlOrder(int orderId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.HtmlOrderRepository.Remove(unitOfWork.HtmlOrderRepository.Get(orderId));
                unitOfWork.Save();
            }

            return new JsonResult("dupa");
        }

        [HttpPost("Action")]
        public IActionResult DeleteServerOrder(int orderId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.ServerOrderRepository.Remove(unitOfWork.ServerOrderRepository.Get(orderId));
                unitOfWork.Save();
            }

            return new JsonResult("dupa");
        }
    }
}
