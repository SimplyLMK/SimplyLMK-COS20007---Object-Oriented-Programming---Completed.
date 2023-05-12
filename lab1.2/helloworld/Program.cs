using System;
using static System.Net.Mime.MediaTypeNames;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Messages[] messages = new Messages[5];
            messages[0] = new Messages("Welcome back!");
            messages[1] = new Messages("What a lovely name");
            messages[2] = new Messages("Great name");
            messages[3] = new Messages("Oh hi!");
            messages[4] = new Messages("That is a silly name");

            
            while (true)
            {
                Console.WriteLine("enter ur name");
                string text = Console.ReadLine();

                switch (text.ToLowerInvariant())
                {
                    case "kha":
                        messages[0].Print();
                        break;

                    case "thinh":
                        messages[1].Print();
                        break;

                    case "matthew mitchell":
                        messages[2].Print();
                        break;

                    case "chris mccarthy":
                        messages[3].Print();
                        break;

                    default:
                        messages[4].Print();
                        break;

                }


            }
            
        }
    }
}