using System.Text.Json;
namespace MyBooksTheyAreAMess;

public class Task4
{
    public void Execute()
    {
        string jsonString = File.ReadAllText("books.json");

        Book[] books = JsonSerializer.Deserialize<Book[]>(jsonString);

        Console.WriteLine("Books with 'The' in their title:");
        FilterByStartingWithThe(books);

        Console.WriteLine("\nBooks written by authors with 't' in their name:");
        FilterByContainingT(books);

        int count = CountBooksWrittenAfter1992(books);
        Console.WriteLine($"\nNumber of books written after 1992: {count}");
    }

    //Return only books that starts on The----------------------------------------------
    public void FilterByStartingWithThe(Book[] books)
    {
        foreach (Book book in books)
        {
            if (book.title.StartsWith("The", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Title: {book.title}, Publication Year: {book.publication_year}, Author: {book.author}, ISBN: {book.isbn}");
            }
        }
    }


    //filter by T in the authors name--------------------------------------------------
    public void FilterByContainingT(Book[] books)
    {
        foreach (Book book in books)
        {
            if (book.author.Contains("t") || book.author.Contains("T"))
            {
                Console.WriteLine($"Title: {book.title}, Publication Year: {book.publication_year}, Author: {book.author}, ISBN: {book.isbn}");
            }
        }
    }
    //filter by number of books written after 1992--------------------------------------
    public int CountBooksWrittenAfter1992(Book[] books)
    {
        int count = 0;
        foreach (Book book in books)
        {
            if (book.publication_year > 1992)
            {
                count++;
            }
        }
        return count;
    }


    public class Book
    {
        public string title { get; set; }
        public int publication_year { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
    }
}