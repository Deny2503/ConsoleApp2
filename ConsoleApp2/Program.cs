namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            /*context.Students.Remove(student);
            context.SaveChanges();*/

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Добавить студента");
                Console.WriteLine("2 - Вывести список студентов");
                Console.WriteLine("3 - Удалить студента");
                Console.WriteLine("4 - Обновить данные студента");
                Console.WriteLine("0 - Выход");
                Console.Write("Введите ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
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

                        context.Students.Add(student);
                        context.SaveChanges();
                        Console.WriteLine("Студент добавлен!\n");
                        Console.Clear();
                        break;

                    case "2":
                        var students = context.Students.ToList();
                        Console.WriteLine("Список студентов:");
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.Name} {s.Age} {s.Email}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.Write("Введите критерии удаления (Имя Возраст, можно оставить пустым): ");
                        var deleteInput = Console.ReadLine().Split(' ');
                        var studentsToDelete = context.Students.ToList();

                        if (deleteInput.Length > 0 && !string.IsNullOrWhiteSpace(deleteInput[0]))
                        {
                            studentsToDelete = studentsToDelete.Where(s => s.Name == deleteInput[0]).ToList();
                        }

                        if (deleteInput.Length > 1 && int.TryParse(deleteInput[1], out int deleteAge))
                        {
                            studentsToDelete = studentsToDelete.Where(s => s.Age == deleteAge).ToList();
                        }

                        context.Students.RemoveRange(studentsToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Удаление завершено!\n");
                        Console.Clear();
                        break;
                    case "4":
                        Console.Write("Введите критерии обновления (Имя Возраст, можно оставить пустым): ");
                        var updateInput = Console.ReadLine().Split(' ');
                        var studentsToUpdate = context.Students.ToList();

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
                        context.Students.UpdateRange(studentsToUpdate);
                        context.SaveChanges();
                        Console.WriteLine("Обновление завершено!\n");
                        Console.Clear();
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
            /*var studentDb = context.Students.ToList();

            var res = studentDb
                .GroupBy(student => new {student.Name, student.Age, student.Email})
                .Where(s => s.Count() > 1)
                .SelectMany(s => s.Skip(1))
                .ToList();
            context.RemoveRange(res);
            context.SaveChanges();

            var res = studentDb.FirstOrDefault(student => student.Name == "Дима" && student.Age == 20);

            res.Age = 21;
            context.Update(res);
            context.SaveChanges();*/
        }
    }
}
