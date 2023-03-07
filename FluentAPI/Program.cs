namespace FluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User ali = new User("Ali", 27, true);
                
                db.Users.Add(ali);
                db.SaveChanges();

                Console.WriteLine("Objects are created successfully.");
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    if (u.IsMarried) 
                        Console.WriteLine($"{ u.Id }. { u.Name } - { u.Age }, Женат/Замужем");
                    else
                        Console.WriteLine($"{ u.Id }. { u.Name } - { u.Age }, Не женат/Не замужем");
                }
            }
        }
    }
}