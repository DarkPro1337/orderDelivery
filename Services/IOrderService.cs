using Microsoft.EntityFrameworkCore;
using orderDelivery.Data;
using orderDelivery.Models;
using orderDelivery.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderDelivery.Services
{
    public interface IOrderService
    {
        Task Create(CreateOrderViewModel model);
        Task<IEnumerable<OrderModel>> GetAllOrders();
        Task Delete(Guid guid);
        Task<OrderModel> GetOrder(Guid guid);
        Task Edit(OrderModel order);
    }

    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        public OrderService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(CreateOrderViewModel model)
        {
            int orderID = _db.Orders.Count();
            
            OrderModel order = new OrderModel()
            {
                OrderID = orderID,
                SenderCity = model.SenderCity,
                SenderAddress = model.SenderAddress,
                RecipientCity = model.RecipientCity,
                RecipientAddress = model.RecipientAddress,
                PackageWeight = model.PackageWeight,
                PickupDate = model.PickupDate
            };
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Guid guid)
        {
            _db.Orders.Remove(await _db.Orders.FirstOrDefaultAsync(y => y.ID == guid));
            await _db.SaveChangesAsync();
        }

        public async Task<OrderModel> GetOrder(Guid guid)
        {
            return await _db.Orders.FirstOrDefaultAsync(y => y.ID == guid);
        }

        public async Task Edit(OrderModel order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            return await _db.Orders.AsNoTracking().ToListAsync();
        }
    }
}
