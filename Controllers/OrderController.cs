using Microsoft.AspNetCore.Mvc;
using orderDelivery.Models;
using orderDelivery.Services;
using orderDelivery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetAllOrders());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            await _orderService.Create(model);
            return RedirectToAction("Index");
        }

        // Функция удаления заказа имплементирована, но не используется из-за вероятности коллизий в номере заказа.
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid guid)
        {
            return View(await _orderService.GetOrder(guid));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderModel model)
        {
            await _orderService.Edit(model);
            return RedirectToAction("Index");
        }
    }
}
