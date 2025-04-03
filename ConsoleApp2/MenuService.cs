using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL.Entities;
using ConsoleApp2.DAL.NewFolder;

namespace ConsoleApp2
{
    public class MenuService
    {
        private StudentService studSer = new StudentService();
        private UserService userSer = new UserService();
        private OrderService ordSer = new OrderService();
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Добавить студента");
                Console.WriteLine("2 - Вывести список студентов");
                Console.WriteLine("3 - Удалить студента");
                Console.WriteLine("4 - Обновить данные студента");
                Console.WriteLine("5 - Добавить пользователя");
                Console.WriteLine("6 - Вывести список пользователей и их заказы");
                Console.WriteLine("7 - Добавить к пользователю заказ");
                Console.WriteLine("8 - Вывести определенного пользователя");
                Console.WriteLine("0 - Выход");
                Console.Write("Введите ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "2":
                        DisplayStudents();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "3":
                        DeleteStudent();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "4":
                        UpdateStudent();
                        Console.Clear();
                        Thread.Sleep(4000);
                        break;

                    case "5":
                        AddUser();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "6":
                        DisplayUsersWithOrders();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "7":
                        AddOrderToUser();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case "8":
                        DisplaySpecificUser();
                        Console.Clear();
                        Thread.Sleep(4000);
                        break;

                    case "0":
                        Console.WriteLine("Выход из программы.");
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод, попробуйте снова.\n");
                        Console.Clear();
                        break;
                }
            }
        }

        private void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите возраст студента: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Введите email студента: ");
            string email = Console.ReadLine();

            var student = new Student
            {
                Name = name,
                Age = age,
                Email = email
            };

            studSer.Add(student);
            Console.WriteLine("Студент добавлен!\n");
        }

        private void DisplayStudents()
        {
            Console.WriteLine("Список студентов:");
            ShowStudents(studSer.GetAll());
            Console.WriteLine();
        }

        private void DeleteStudent()
        {
            Console.Write("Введите критерии удаления (Имя Возраст, можно оставить пустым): ");
            var deleteInput = Console.ReadLine().Split(' ');

            var studentsToDelete = studSer
                .GetAll()
                .Where(s => (deleteInput.Length < 1 || s.Name == deleteInput[0]) &&
                            (deleteInput.Length < 2 || s.Age.ToString() == deleteInput[1]))
                .ToList();

            ShowStudents(studentsToDelete);
            Console.WriteLine("Удаление завершено!\n");
        }

        private void UpdateStudent()
        {
            Console.Write("Введите критерии обновления (Имя Возраст, можно оставить пустым): ");
            var updateInput = Console.ReadLine().Split(' ');
            var studentsToUpdate = studSer.GetAll();

            if (updateInput.Length > 0 && !string.IsNullOrWhiteSpace(updateInput[0]))
            {
                studentsToUpdate = studentsToUpdate.Where(s => s.Name == updateInput[0]).ToList();
            }

            if (updateInput.Length > 1 && int.TryParse(updateInput[1], out int updateAge))
            {
                studentsToUpdate = studentsToUpdate.Where(s => s.Age == updateAge).ToList();
            }

            foreach (var studentToUpdate in studentsToUpdate)
            {
                Console.Write("Введите новые данные (Возраст Email): ");
                var newData = Console.ReadLine().Split(' ');
                if (newData.Length < 2)
                {
                    Console.WriteLine("Некорректный ввод!");
                    break;
                }
                studentToUpdate.Age = int.Parse(newData[0]);
                studentToUpdate.Email = newData[1];
            }

            ShowStudents(studentsToUpdate);

            Console.WriteLine("Обновление завершено!\n");
        }

        private void AddUser()
        {
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();
            var user = new User 
            { 
                Name = name 
            };
            userSer.Add(user);
            Console.WriteLine("Пользователь добавлен!\n");
        }

        private void DisplayUsersWithOrders()
        {
            var users = userSer.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"Пользователь: {user.Name}");
                var orders = userSer.GetOrdersByUserId(user.Id);
                if (orders.Any())
                {
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"   Заказ ID: {order.Id}, Продукт: {order.ProductName}, Дата: {order.DateCreated}");
                    }
                }
                else
                {
                    Console.WriteLine("   Нет заказов.");
                }
            }
            Console.WriteLine();
        }

        private void AddOrderToUser()
        {
            Console.Write("Введите ID пользователя для добавления заказа: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Введите название продукта: ");
            string productName = Console.ReadLine();

            var order = new Order
            {
                ProductName = productName,
                DateCreated = DateTime.Now
            };

            userSer.AddOrderToUser(userId, order);
            Console.WriteLine("Заказ добавлен пользователю!\n");
        }

        private void DisplaySpecificUser()
        {
            Console.Write("Введите ID пользователя: ");
            int userId = int.Parse(Console.ReadLine());

            var user = userSer.GetById(userId);
            if (user != null)
            {
                Console.WriteLine($"Пользователь: {user.Name}");
                var orders = userSer.GetOrdersByUserId(user.Id);
                if (orders.Any())
                {
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"   Заказ ID: {order.Id}, Продукт: {order.ProductName}, Дата: {order.DateCreated}");
                    }
                }
                else
                {
                    Console.WriteLine("   Нет заказов.");
                }
            }
            else
            {
                Console.WriteLine("Пользователь не найден!");
            }
            Console.WriteLine();
        }

        private void FinalOperations()
        {
            var studentDb = studSer.GetAll();

            /*var res = studentDb
                .GroupBy(student => new { student.Name, student.Age, student.Email })
                .Where(s => s.Count() > 1)
                .SelectMany(s => s.Skip(1))
                .ToList();

            foreach (var student in res)
            {
                studSer.Delete(student);
            }

            var result = studentDb.FirstOrDefault(student => student.Name == "Дима" && student.Age == 20);
            if (result != null)
            {
                result.Age = 21;
                studSer.Update(result);
            }*/

            ShowStudents(studSer.GetOrderByAge());

            Console.WriteLine("_________________________");

            ShowStudents(studSer.GetOrderByName());
        }

        private void ShowStudents(IEnumerable<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name} {s.Age} {s.Email}");
            }
            Console.WriteLine();
        }
    }
}
