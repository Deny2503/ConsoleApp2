
using ConsoleApp2.DAL.NewFolder;
using ConsoleApp2.DAL;

namespace ConsoleApp2
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public void Add(Student student)
        {
            _studentRepository.Add(student);
        }
        public void AddRange(List<Student> streams)
        {
            _studentRepository.AddRange(streams);
        }
        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }
        public Student? GetById(int id)
        {
            var res = _studentRepository.GetById(id);
            return res == null 
                ? _studentRepository.GetAll().FirstOrDefault(x => x.Id == id)
                : res;
        }
        public Student GetByName(string name)
        {
            return _studentRepository.GetByName(name);
        }
        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public List<Student> GetOrderByAge()
        {
            return GetAll().OrderBy(x => x.Age).ToList();
        }
        public List<Student> GetOrderByName()
        {
            return GetAll().OrderBy(x => x.Name).ToList();
        }
    }
}
