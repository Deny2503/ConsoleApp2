using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
