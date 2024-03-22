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

        int count2004 = CountBooksWrittenBefore2004(books);
        Console.WriteLine($"Number of books written before 2004: {count2004}");

        List<string> isbnNumbers = GetIsbnNumbersForAuthor(books, "John Doe");
        Console.WriteLine("\nISBN numbers of books written by John Doe:");
        foreach (string isbn in isbnNumbers)
        {
            Console.WriteLine(isbn);
        }


        Console.WriteLine("\nList of books alphabetically ascending:");
        ListBooksAlphabeticallyAscending(books);


        Console.WriteLine("\nList of books chronologically ascending:");
        ListBooksChronologicallyAscending(books);
    }




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
  



    public int CountBooksWrittenBefore2004(Book[] books)
    {
        int count = 0;
        foreach (Book book in books)
        {
            if (book.publication_year < 2004)
            {
                count++;
            }
        }
        return count;
    }




    public List<string> GetIsbnNumbersForAuthor(Book[] books, string authorName)
    {
        List<string> isbnNumbers = new List<string>();
        foreach (Book book in books)
        {
            if (book.author.Equals(authorName, StringComparison.OrdinalIgnoreCase))
            {
                isbnNumbers.Add(book.isbn);
            }
        }
        return isbnNumbers;
    }
   



    public void ListBooksAlphabeticallyAscending(Book[] books)
    {
        var sortedBooks = books.OrderBy(book => book.title, StringComparer.OrdinalIgnoreCase);
        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"Title: {book.title}, Publication Year: {book.publication_year}, Author: {book.author}, ISBN: {book.isbn}");
        }
    }
  



    public void ListBooksChronologicallyAscending(Book[] books)
    {
        var sortedBooks = books.OrderBy(book => book.publication_year);
        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"Title: {book.title}, Publication Year: {book.publication_year}, Author: {book.author}, ISBN: {book.isbn}");
        }
    }
    
    

    public class Book
    {
        public string title { get; set; }
        public int publication_year { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
    }
}