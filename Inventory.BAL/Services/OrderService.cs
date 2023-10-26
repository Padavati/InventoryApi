using Inventory.DAL.Repository;
using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BAL.Services
{
    public class OrderService
    {

        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //Add Order
        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
        //Delete Order
        public void DeleteOrder(int OrderId)
        {
            _orderRepository.DeleteOrder(OrderId);
        }
        //Get Order by Id
        public Order GetOrderById(int OrderId)
        {
            return _orderRepository.GetOrderById(OrderId);
           
        }
        //Get all orders
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        //update the order
        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

    }

}

