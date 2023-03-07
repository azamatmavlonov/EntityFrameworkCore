namespace IEnumerableSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext applicationContext = new ApplicationContext()) 
            {
                // обычный вариант:
                // var users = applicationContext.Users.ToList();

                // IEnumerable вариант:
                IEnumerable<User> userIEnum = applicationContext.Users;
                var users = userIEnum.Where(p => p.Id < 7).ToList();

                Console.WriteLine("IEnumerable of users:");

                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Id} - {user.Name}");
                }
            }
        }
    }
}