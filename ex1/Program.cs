using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    class Program
    {
        public delegate void StringOperation(string s);
        static void Main(string[] args)
        {
            try
            {
                StringOperation stringOperation = null;
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("Give input string");
                    string input = Console.ReadLine();
                    Console.WriteLine("MENU - Choose an option\n***************\n\n0: Exit\n1: String to Uppercase\n2: String to Lowercase\n3: Capitalize String\n4: Reverse String");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "0":
                            loop = false;
                            break;
                        case "1":
                            stringOperation = new StringOperation(Uppercase);
                            break;
                        case "2":
                            stringOperation = new StringOperation(Lowercase);
                            break;
                        case "3":
                            stringOperation = new StringOperation(Capitalize);
                            break;
                        case "4":
                            stringOperation = new StringOperation(Reverse);
                            break;
                    }
                    stringOperation(input);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Uppercase(string s)
        {
            Console.WriteLine(s.ToUpper());
        }

        static void Lowercase(string s)
        {
            Console.WriteLine(s.ToLower());
        }

        static void Capitalize(string s)
        {
            Console.WriteLine(s.First().ToString().ToUpper() + s.Substring(1));
        }

        static void Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));
        }
    }
}
