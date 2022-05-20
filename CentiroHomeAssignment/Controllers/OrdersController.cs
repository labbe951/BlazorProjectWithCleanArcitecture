using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CentiroHomeAssignment.Services.Features.Orders;
using CentiroHomeAssignment.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace CentiroHomeAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        //GetAll()
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            // TODO: Return all orders to a view
            var orderResponses = await _orderService.GetAllOrders();
            if (orderResponses != null)
            {
                return Ok(orderResponses);
            }
            else
            {
                return BadRequest(orderResponses);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ImportOrders([FromBody]string filePath) 
        {
            await _orderService.ImportOrders(filePath);
            
            return Ok();
        }












        //[HttpGet("{orderNo}")]
        //public async Task<ActionResult<OrderResponse>> GetByOrderNumber(int orderNumber)
        //{
        //    // TODO: Return the specific order to a view
        //    var orderResponse = await _orderService.GetOrderByOrderNo(orderNumber);
        //    if (orderResponse != null)
        //    {
        //        return Ok(orderResponse);
        //    }
        //    else
        //    {
        //        return BadRequest(orderResponse);
        //    }
        //}

       
       
    }
}
