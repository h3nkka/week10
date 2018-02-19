using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ex2
{
    class MailBook
    {
        public readonly List<Friend> Friends;
        private static string SearchString { get; set; }
        public MailBook()
        {
            try
            {
                string[] textData = File.ReadAllLines("tutut.csv");
                Console.WriteLine("Read file successfully. {0} names were found.", textData.Count());
                string[] temp;
                Friends = new List<Friend>();

                for (int i = 0; i < textData.Count(); i++)
                {
                    temp = textData[i].Split(';');
                    Friends.Add(new Friend(temp[0],temp[1]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddFriend(Friend f)
        {
            try
            {
                Friends.Add(f);
                StreamWriter sw = new StreamWriter("tutut.csv");
                foreach (Friend friend in Friends)
                {
                    sw.WriteLine(friend.Name + ";" + friend.Email);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Friend> Search(string s)
        {
            try
            {
                SearchString = s;
                Predicate<Friend> predicate = FindName;
                return Friends.FindAll(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private bool FindName(Friend friend)
        {
            return friend.Name.Contains(SearchString);
        }
    }
}
