using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
    [Route("api/serverorders")]
    public class ServerOrdersController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ServerOrdersController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddServerOrder([FromBody] ServerOrder order)
        {
            Debug.WriteLine("Adding new order with frequency= " + order.Frequency + " , orderTarget= " + order.TargetAddress);

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
                    new ServerJobDetailComposer<ServerOrderJob>(order.Id, order.TargetAddress),
                    new SimpleTriggerComposer(order.Frequency, order.Id));

            await addingServerProvider.AddOrder();

            return new JsonResult(order.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServerOrder([FromQuery] int orderId)
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

        [HttpGet]
        public IActionResult GetServerOrder([FromQuery] int orderId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var order = unitOfWork.ServerOrderRepository.Get(orderId);
                if (order == null)
                {
                    return BadRequest("Order not found");
                }
                else
                {
                    return new JsonResult(order);
                }

            }

        }

        [HttpGet("GetAll")]
        public IActionResult GetAllServerOrders()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                return new JsonResult(unitOfWork.ServerOrderRepository.GetAll());
            }
        }

    }
}