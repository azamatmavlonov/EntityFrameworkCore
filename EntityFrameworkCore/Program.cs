using System.Reflection.Metadata;

namespace EFCoreCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SomeContext db = new SomeContext())
            {
                // создаем два объекта User
                User ali = new User { Name = "Ali", Age = 18 };
                User alice = new User { Name = "Alica", Age = 17 };
                User abubakr = new User { Name = "Abubakr", Age = 13 };

                // добавляем их в бд
                db.Users.Add(ali);
                db.Users.Add(alice);
                db.Users.Add(abubakr);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{ u.Id }.{ u.Name } - { u.Age }");
                }
            }
        }
    }
}