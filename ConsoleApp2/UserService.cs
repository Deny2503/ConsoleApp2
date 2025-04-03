using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL;
using ConsoleApp2.DAL.Entities;

namespace ConsoleApp2
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void AddOrderToUser(int userId, Order order)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                order.UserId = user.Id;
                _orderRepository.Add(order);
                Console.WriteLine("Заказ успешно добавлен!");
            }
            else
            {
                Console.WriteLine("Пользователь не найден!");
            }
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepository.GetByUserId(userId);
        }
    }
}
