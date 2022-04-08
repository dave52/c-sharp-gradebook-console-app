using Xunit;
using GradeBook;
using System;

namespace GradeBook.tests;

public class TypeTests
{
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        // assert
        Assert.Equal("Book 1", book1.Name);
        Assert.NotSame(book1, book2); // assert that the two objects are the same object type
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Equal("Book 1", book2.Name);
        Assert.Same(book1, book2);
    }

    [Fact]
    public void CanRenameBook()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
    }

    [Fact]
    public void CSharpCanPassbyReference()
    {
        var book1 = GetBook("Book 1");
        GetBookSetNameByRef(ref book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void ValueTypeAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(x);

        var xRef = GetInt();
        SetIntByRef(ref xRef);

        Assert.Equal(3, x); // returns 3, not 42 because c# pass by value by default, not reference
        Assert.Equal(42, xRef);
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "C Sharp";
        string upper = MakeUppercase(name);

        Assert.Equal("C Sharp", name);
        Assert.Equal("C SHARP", upper);
    }

  private string MakeUppercase(string name)
  {
    return name.ToUpper();
  }

  private void SetIntByRef(ref int y)
  {
    y = 42;
  }

  private void SetInt(int z)
  {
    // parameter is copy of whatever is passed as argument, and is scoped to the method
    z = 42;
  }

  private int GetInt()
  {
    return 3;
  }

  private void GetBookSetNameByRef(ref Book book, string name)
  {
    book = new Book(name);
  }

  private void GetBookSetName(Book book, string name)
  {
    book = new Book(name);
  }

  Book GetBook(string name)
    {
        return new Book(name);
    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }
}