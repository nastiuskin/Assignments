namespace Assignment_9
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public Guid MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}
