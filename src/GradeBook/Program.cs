// using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 32.13;
            double y = 69.42;
            
            var bookerT = new Book("Booker T");
            bookerT.AddGrade(x);
            bookerT.AddGrade(y);
            var stats = bookerT.GetStatistics();


            Console.WriteLine(x + y);
            Console.WriteLine($"The letter grade is {stats.Letter}");

            if (args.Length > 0)
			{
                Console.WriteLine($"Hello {args[0]}!");
			}
            else
			{
                Console.WriteLine("Hello!");
			}
        }
    }
}
