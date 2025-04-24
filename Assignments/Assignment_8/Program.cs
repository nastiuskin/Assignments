using System.Reflection.Metadata.Ecma335;

namespace Assignment_8;
public class Program
{
    public static void Main(string[] args)
    {
        //Create a collection

        List<Book> books = new List<Book>
        {
            new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopia", Pages = 328, Rating = 4.8 },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Pages = 310, Rating =8.8 },
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Genre = "Programming", Pages = 464, Rating = 4.5 },
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Classic", Pages = 277, Rating = 3.9 },
            new Book { Title = "Dune", Author = "Frank Herbert", Genre = "Sci-Fi", Pages = 412, Rating = 9.7 }
        };

        //Manipulate collection via Delegates

        var longBooks = FilterBooks(books, HasManypages);
        Console.WriteLine("Books with more than 300 pages:\n");
        longBooks.ForEach(b => Console.WriteLine(b.Title));

        var popularBooks = FilterBooks(books, HasHighRating);
        Console.WriteLine("\nBooks with rating higher than 8:\n");
        popularBooks.ForEach(b => Console.WriteLine(b.Title));
        Console.WriteLine();

        //Rewrite using anonymous functions

        List<Book> longBooksV2 = FilterBooks(books, delegate (Book book)
        {
            return book.Pages > 300;
        });

        List<Book> popularBooksV2 = FilterBooks(books, delegate (Book book)
        {
            return book.Rating >= 8;
        });

        //Rewrite using anonymous functions

        List<Book> longBooksV3 = FilterBooks(books, book => book.Pages > 300);
        List<Book> popularBooksV3 = FilterBooks(books, book => book.Rating >= 8);

        //Use extension methods on the collection

        books.PrintAll();
        books.FilterByGenreAndRating("Dystopia", 5);

        //Use Select/Where operations on the collection

        var longBooksV4 = books.Where(x => x.Pages > 300)
                                 .Select(x => new
                                 {
                                     Title = x.Title,
                                     Pages = x.Pages
                                 }).ToList();

        longBooksV4.ForEach(x => Console.WriteLine($"Title: {x.Title}, Pages: {x.Pages}"));

        Console.WriteLine();

        var popularBooksV4 = books.Where(x => x.Rating >= 8)
                                 .Select(x => new
                                 {
                                     Title = x.Title,
                                     Rating = x.Rating
                                 }).ToList();

        popularBooksV4.ForEach(x => Console.WriteLine($"Title: {x.Title}, Rating: {x.Rating}"));
    }


    public delegate bool BookFilter(Book book);
    public static List<Book> FilterBooks(List<Book> books, BookFilter filter)
    {
        List<Book> filteredBooks = new List<Book>();
        foreach (var book in books)
        {
            if (filter(book))
                filteredBooks.Add(book);
        }

        return filteredBooks;
    }

    public static bool HasManypages(Book book) => book.Pages > 300;
    public static bool HasHighRating(Book book) => book.Rating >= 8;
}




