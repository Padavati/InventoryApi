using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int OrderId);
        Order GetOrderById(int OrderId);
        IEnumerable<Order> GetOrders();
    }
}
