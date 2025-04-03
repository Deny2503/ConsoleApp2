using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL.Entities;

namespace ConsoleApp2.DAL
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }
    }
}
