using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace EFCoreDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Добавление данных в базу данных
            using (TestContext db = new TestContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // создаем объекты User
                User ali = new User { Name = "Ali", Age = 18 };
                User alice = new User { Name = "Alica", Age = 17 };
                User abubakr = new User { Name = "Abubakr", Age = 13 };

                // добавляем их в бд
                db.Users.Add(ali);
                db.Users.Add(alice);
                db.Users.Add(abubakr);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены.");
            }

            // получение данных из базы данных
            using (TestContext db = new TestContext())
            {
                var users = db.Users.ToList();

                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // редактирование данных в базе данных
            using (TestContext db = new TestContext())
            {
                // получаем первый объект
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Ravshan";
                    user.Age = 27;
                    db.SaveChanges();
                }

                // вывод данных после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // удаление данных из базы данных
            using (TestContext db = new TestContext())
            {
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();  
                foreach (User u in users)
                {
                    Console.WriteLine($"{ u.Id }.{ u.Name } - { u.Age }");
                }
            }

            /*
            var builder = new ConfigurationBuilder();
            
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            var options = optionsBuilder.UseNpgsql(connectionString).Options;

            using (TestContext db = new TestContext(options))
            {
                var users = db.Users.ToList();
                foreach (User user in users)
                {
                    Console.WriteLine($"{ user.Id }.{ user.Name } - { user.Age }");
                }
            }
            */
        }
    }
}