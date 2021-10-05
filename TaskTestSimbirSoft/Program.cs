using System;

namespace TaskTestSimbirSoft
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckURL c = new CheckURL();
            WordWork w = new WordWork();

            var url = Console.ReadLine();
            string checkedURL = c.Check(url);

            if (checkedURL != null)
            {
                w.PrintWord(checkedURL);
            }
            else
            {
                Console.WriteLine($"{url} is invalid!");
            }
        }
    }
}