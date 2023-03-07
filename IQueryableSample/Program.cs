namespace IQueryableSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                IQueryable<User> usersIQuer = applicationContext.Users;

                usersIQuer.Where(p => p.Id < 7);
                usersIQuer.Where(p => p.Name == "Abduvali");

                var users = usersIQuer.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"{ user.Id } - { user.Name }");
                }
            }
        }
    }
}