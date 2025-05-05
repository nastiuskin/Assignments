namespace Assignment_15.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; }
        public string Author { get; }
        public decimal Price { get; }

        public Book(string title, string author, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
