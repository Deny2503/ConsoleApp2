using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL.Entities;

namespace ConsoleApp2.DAL
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void AddRange(List<User> users)
        {
            _context.AddRange(users);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public User GetByName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name == name);
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
