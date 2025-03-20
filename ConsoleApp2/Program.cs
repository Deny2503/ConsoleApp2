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
        }
    }
}
