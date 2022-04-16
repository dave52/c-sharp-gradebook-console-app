// using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
    {

      var bookerT = new DiskBook("Booker T");
      bookerT.GradeAdded += OnGradeAdded;
      bookerT.GradeAdded += OnGradeAdded;
      bookerT.GradeAdded -= OnGradeAdded;
      bookerT.GradeAdded += OnGradeAdded;

      EnterGrades(bookerT);

      var stats = bookerT.GetStatistics();

      Console.WriteLine($"The lowest grade is {stats.Low}");
      Console.WriteLine($"The highest grade is {stats.High}");
      Console.WriteLine($"The average grade is {stats.Average:N1}");
      Console.WriteLine($"The letter grade is {stats.Letter}");

      // if (args.Length > 0)
      // {
      //     Console.WriteLine($"Hello {args[0]}!");
      // }
      // else
      // {
      //     Console.WriteLine("Hello!");
      // }
    }

    private static void EnterGrades(Book book)
    {
      while (true)
      {
        Console.WriteLine("Enter a number grade or 'q' to quit");
        var input = Console.ReadLine();

        if (input == "q")
        {
          break;
        }

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
