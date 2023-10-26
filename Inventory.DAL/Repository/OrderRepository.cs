using Inventory.DAL.Data;
using Inventory.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public class OrderRepository:IOrderRepository
    {
        ProductDbContext _productDbContext;
        public OrderRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public void AddOrder(Order order)
        {
            _productDbContext.orders.Add(order);
            _productDbContext.SaveChanges();
        }

        public void DeleteOrder(int OrderId)
        {
            var order = _productDbContext.orders.Find(OrderId);
            _productDbContext.orders.Remove(order);
            _productDbContext.SaveChanges();
        }

        public Order GetOrderById(int OrderId)
        {
            return _productDbContext.orders.Find(OrderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _productDbContext.orders.ToList();
        }

        public void UpdateOrder(Order order)
        {
            _productDbContext.Entry(order).State = EntityState.Modified;
            _productDbContext.SaveChanges();
        }
    }
}

