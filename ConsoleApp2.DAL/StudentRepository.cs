using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleApp2.DAL.NewFolder;

namespace ConsoleApp2.DAL
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository() 
        {
            _context = new AppDbContext();
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void AddRange(List<Student> streams)
        {
            _context.AddRange(streams);
            _context.SaveChanges();
        }
        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }
        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(x => x.Name == name);
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}
