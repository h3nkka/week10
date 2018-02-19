using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MailBook mailBook = new MailBook();
                mailBook.Friends.ForEach(x => Console.WriteLine(x.Name));
                Console.WriteLine("\nSearch for a name by inputting a string.");
                mailBook.Search(Console.ReadLine()).ForEach(x => Console.WriteLine(x.Name));
                Friend friend1 = new Friend("Nikita Mämmelä", "nikitin@russia.ru");
                mailBook.AddFriend(friend1);
                mailBook.Friends.ForEach(x => Console.WriteLine(x.Name));
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }      
    }
}
