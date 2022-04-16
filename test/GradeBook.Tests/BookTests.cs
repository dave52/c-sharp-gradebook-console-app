using Xunit;
using GradeBook;

namespace GradeBook.tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        // arrange
        var book = new InMemoryBook("Booker T");
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        // book.AddGrade(105);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(83.9, result.Average, 1);
        Assert.Equal(90.5, result.High, 1);
        Assert.Equal(77.3, result.Low, 1);
        Assert.NotEqual(105, result.High, 1);
        Assert.Equal('B', result.Letter);
    }
}