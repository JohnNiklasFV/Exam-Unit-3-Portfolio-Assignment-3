using FunctionsAreAPopping;
using FlattenThoseNumbers;
using LeftAndRightUpAndDownAwayWeGo;
using MyBooksTheyAreAMess;
public class Program
{
    public static void Main(string[] args)
    {
        Task1 FunctionsAreAPopping = new Task1();
        FunctionsAreAPopping.Execute();

        Task2 FlattenThoseNumbers = new Task2();
        FlattenThoseNumbers.Execute();

        Task3 LeftAndRightUpAndDownAwayWeGo = new Task3();
        LeftAndRightUpAndDownAwayWeGo.Execute();

        Task4 MyBooksTheyAreAMess = new Task4();
        MyBooksTheyAreAMess.Execute();
    }
}