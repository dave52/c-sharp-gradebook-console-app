namespace GradeBook
{
  public class Book
  {
    // constructor method name as class as, and initializes a field set below to new List<double>();
    public Book(string name)
    {
      grades = new List<double>();
      this.Name = name;
    }

    // public void AddLetterGrade(char letter)
    // {
    //   switch(letter)
    //   {
    //     case 'A':
    //       AddGrade(90);
    //       break;
    //     case 'B':
    //       AddGrade(80);
    //       break;
    //     case 'C':
    //       AddGrade(70);
    //       break;
    //     case 'D':
    //       AddGrade(60);
    //       break;
    //     default: // 'F'
    //       AddGrade(50);
    //       break;
    //   }
    // }

    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
      }
      else
      {
        Console.WriteLine("Invalid value");
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach(var grade in grades)
      {
        result.High = Math.Max(grade, result.High);
        result.Low = Math.Min(grade, result.Low);
      }


      // rewriting foreach as do while
      // this is brittle as if grades is empty, it will error, instead a while loop is better
      // var index = 0;
      // do
      // {
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Low = Math.Min(grad[index], result.Low);
      //   index++;
      // } while(index < grades.Count);


      // while loop representing the above foreach loop
      // var index = 0;
      // while(index < grades.Count)
      // {
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Low = Math.Min(grades[index], result.Low);
      //   index++;
      // }


      // lastly the for loop version, fancier while loop, don't need var setup outside of loop
      // for (var index = 0; index < grades.Count; index++)
      // {
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Low = Math.Min(grades[index], result.Low);
      // }


      result.Average = grades.Sum() / grades.Count;

      switch(result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        default:  // <= 60.0
          result.Letter = 'F';
          break;
      }

      return result;
      // explicit type declaration
      // List<double> grades = new List<double>()
      // implicit type declaration
      // var grades = new List<double>() { 10.1, 34.1, 454.3, 343.3 };
      // var highGrade = double.MinValue;
      // var lowGrade = double.MaxValue;
      // var result = 0.0;
      // foreach(var number in grades)
      // {
      //     result += number;

      //     highGrade = Math.Max(number, highGrade);
      //     lowGrade = Math.Min(number, lowGrade);
      // }
      // result /= grades.Count;
      // Console.WriteLine($"Average grade is {result:N1}");
      // Console.WriteLine($"The highest grade is {highGrade}");
      // Console.WriteLine($"The lowest grade is {lowGrade}");
    }

    public string Name;
    private List<double> grades; // the field (a var outside of a method) of grades is set to type List<double> but not initialized
  }
}