namespace Assignment_9
{
    public class Musician
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public int YearsActive { get; set; }
        public IEnumerable<Song> Songs { get; set; } = new List<Song>();
    }
}
