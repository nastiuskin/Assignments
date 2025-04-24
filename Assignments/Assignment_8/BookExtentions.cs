namespace Assignment_8
{
    public static class BookExtentions
    {
        public static void PrintAll( this IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Genre: {book.Genre}, Author: {book.Author}, Rating: {book.Rating}");
            }
            Console.WriteLine();
        }

        public static IEnumerable<Book> FilterByGenreAndRating(this IEnumerable<Book> books, string genre, double minRating)
        {
            return books.Where(b => b.Genre == genre && b.Rating >= minRating);
        }
    }
}
