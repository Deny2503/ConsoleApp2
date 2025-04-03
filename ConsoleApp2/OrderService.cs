using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL;
using ConsoleApp2.DAL.Entities;

namespace ConsoleApp2
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
            Console.WriteLine("Заказ успешно добавлен!");
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            Console.WriteLine("Заказ успешно обновлен!");
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                _orderRepository.Delete(order);
                Console.WriteLine("Заказ успешно удален!");
            }
            else
            {
                Console.WriteLine("Заказ не найден!");
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepository.GetByUserId(userId);
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }
    }
}
