using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam_azure.DTOs;
using exam_azure.Entities;
using exam_azure.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exam_azure.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Order> Orders = _context.Orders.ToList();

            List<OrderDTO> data = new List<OrderDTO>();
            foreach (Order p in Orders)
            {
                data.Add(new OrderDTO { Id = p.Id, ItemCode = p.ItemCode, ItemName = p.ItemName, ItemQty = p.ItemQty, OrderDelivery = p.OrderDelivery, OrderAddress = p.OrderAddress, PhoneNumber = p.PhoneNumber });
            }
            return Ok(data);
        }


        [HttpPost]
        public IActionResult CreateOrder(CreateOrder model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order data = new Order { ItemCode = model.ItemCode, ItemName = model.ItemName, ItemQty = model.ItemQty, OrderDelivery = model.OrderDelivery, OrderAddress = model.OrderAddress, PhoneNumber = model.PhoneNumber };
                    _context.Orders.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new OrderDTO { Id = data.Id, ItemCode = data.ItemCode, ItemName = data.ItemName, ItemQty = data.ItemQty, OrderDelivery = data.OrderDelivery, OrderAddress = data.OrderAddress, PhoneNumber = data.PhoneNumber });

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }


        [HttpPut]
        public async Task<IActionResult> Update(EditOrder model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order orderCheck = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.Id);

                    if (orderCheck != null)
                    {
                        Order data = new Order
                        {
                            Id = model.Id,
                            ItemCode = orderCheck.ItemCode,
                            ItemName = orderCheck.ItemName,
                            ItemQty = orderCheck.ItemQty,
                            OrderDelivery = model.OrderDelivery,
                            OrderAddress = model.OrderAddress,
                            PhoneNumber = orderCheck.PhoneNumber,
                        };

                        if (data != null)
                        {
                            _context.Orders.Update(data);
                            await _context.SaveChangesAsync();
                            return NoContent();
                        }

                        return NotFound();
                    }
                    else
                    {
                        return NotFound(); 
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            return BadRequest();
        }
    }
}

