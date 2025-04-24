
using System.Runtime.CompilerServices;

namespace Assignment_9;

public class Program
{
    public static void Main(string[] args)
    {
        var musicians = SeedMusicians();
        var songs = SeedSongs(musicians);


        //JOIN

        var join = songs.Join(musicians,
            s => s.MusicianId,
            m => m.Id,
            (s, m) => new
            {
                Musician = m.Name,
                Song = s.Title
            })
            .ToList();

        join.ForEach(item => Console.WriteLine($"{item.Musician} - {item.Song}"));

        Console.WriteLine();


        //GROUP JOIN 

        var groupJoin = musicians.GroupJoin(songs,
            m => m.Id,
            s => s.MusicianId,
            (musician, relatedSongs) => new
            {
                Musician = musician.Name,
                Songs = relatedSongs
            });

        foreach (var item in groupJoin)
        {
            Console.WriteLine($"{item.Musician}:");

            if (!item.Songs.Any())
                Console.WriteLine("   (no songs)");

            item.Songs.ToList().ForEach(song => Console.WriteLine($"   - {song.Title}"));
        }


        //ZIP

        var zippik = musicians
            .Zip(songs, (m, s) => new
            {
                Musician = m.Name,
                Song = s.Title,
                IsOwned = m.Id == s.MusicianId
            })
            .ToList();

        zippik.ForEach(x => Console.WriteLine($"{x.Musician} - {x.Song} => Status: {x.IsOwned}"));


        //GROUP BY

        var grouppik = songs
            .GroupBy(x => x.MusicianId)
            .Select(group => new
            {
                MusicianId = group.Key,
                Count = group.Count()
            })
            .ToList();

        grouppik.ForEach(g => Console.WriteLine($"{g.MusicianId} => {g.Count}"));


        //CONCAT

        Console.WriteLine("\nConcat operation:");

        var newSongs = new List<string> { "Song1", "Song2", "Song3" };
        var favoriteSongs = new List<string> { "Song4", "Song1", "Song5" };

        var allSongsWithDuplicates = newSongs.Concat(favoriteSongs);

        Console.WriteLine(allSongsWithDuplicates.Count());


        //UNION

        Console.WriteLine("\nUnion operation:");

        var allSongsWithoutDublicates = newSongs.Union(favoriteSongs);

        Console.WriteLine(allSongsWithoutDublicates.Count());


        //INTERSECT 

        Console.WriteLine("\nIntersect operation:");

        var commonSongs = newSongs.Intersect(favoriteSongs);

        Console.WriteLine(commonSongs.Count());


        //EXCEPT

        Console.WriteLine("\nExcept operation:");

        var songsFromFirstCollectionOnly = newSongs.Except(favoriteSongs);

        Console.WriteLine(songsFromFirstCollectionOnly.Count());


        //TO DICTIONARY

        var songDictionary = songs.ToDictionary(s => s.Id, s => s.Title);

        Console.WriteLine("Songs as dictionary:");

        foreach (var item in songDictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }


        //OF TYPE

        var mixedList = new List<object> { new Song { Title = "Song1" }, "Not a song", new Song { Title = "Song2" } };

        var songsOnly = mixedList
            .OfType<Song>()
            .ToList();

        Console.WriteLine("Songs only:");
        songsOnly.ForEach(s => Console.WriteLine(s.Title));


        //CAST 

        try
        {
            var castedSongs = mixedList
                .Cast<Song>()
                .ToList();

            castedSongs.ForEach(x => Console.WriteLine(x.Title));
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        //SUM

        double totalDuration = songs.Sum(s => s.Duration);

        Console.WriteLine($"\nTotal duration of all songs: {totalDuration} minutes");


        //MIN

        double minDuration = songs.Min(s => s.Duration);

        Console.WriteLine($"\nShortest song duration: {minDuration} minutes");


        //ANY

        bool hasHighRating = songs.Any(s => s.Rating > 4.5);

        Console.WriteLine($"\nAre there any songs with rating greater than 4.5? {hasHighRating}");


        //ALL

        bool allHighRated = songs.All(s => s.Rating > 3.5);

        Console.WriteLine($"\nDo all songs have a rating greater than 3.5? {allHighRated}\n");


        //DISTINCT

        var songTitles = songs.Select(s => s.Title).Distinct().ToList();

        songTitles.ForEach(title => Console.WriteLine(title));


        //CONTAINS

        var containsSong = songs.Select(s => s.Title).Contains("Echoes");

        Console.WriteLine(containsSong);


        //AGGREGATE

        var totalRatingCount = songs
            .Select(x => x.Rating)
            .Aggregate((total, next) => total + next);

        Console.WriteLine(totalRatingCount);
        Console.WriteLine();

        var longestTitle = songs.Select(x => x.Title).Aggregate((longest, next) => longest.Length > next.Length ? longest : next);

        Console.WriteLine(longestTitle);


        //FirstOrDefault

        var firstSong = songs.FirstOrDefault();

        Console.WriteLine($"First song: {firstSong?.Title}");


        //SingleOrDefault 

        var song = songs.SingleOrDefault(x => x.Title == "Echoes");

        var rating = song is null ? 0 : song.Rating;

        Console.WriteLine(rating);


        //REPEAT

        var repeatedSongs = Enumerable.Repeat(new Song { Title = "Repeated Song", Duration = 3.5 }, 3)
            .ToList();

        repeatedSongs.ForEach(song => Console.WriteLine(song.Title));
    }

    static List<Musician> SeedMusicians()
    {
        return new List<Musician>
            {
                new Musician { Id = Guid.NewGuid(), Name = "Alice", Country = "USA", Genre = "Rock", YearsActive = 10 },
                new Musician { Id = Guid.NewGuid(), Name = "Bob", Country = "UK", Genre = "Jazz", YearsActive = 15 },
                new Musician { Id = Guid.NewGuid(), Name = "Carlos", Country = "Brazil", Genre = "Samba", YearsActive = 8 },
            };
    }

    static List<Song> SeedSongs(List<Musician> musicians)
    {
        return new List<Song>
            {
                new Song { Id = Guid.NewGuid(), Title = "Firestorm", Duration = 3.5, Year = 2021, Rating = 4.7, MusicianId = musicians[0].Id, Musician = musicians[0] },
                new Song { Id = Guid.NewGuid(), Title = "Midnight Groove", Duration = 5.2, Year = 2018, Rating = 4.2, MusicianId = musicians[1].Id, Musician = musicians[1] },
                new Song { Id = Guid.NewGuid(), Title = "Sunset Samba", Duration = 4.8, Year = 2020, Rating = 4.8, MusicianId = musicians[1].Id, Musician = musicians[1] },
                new Song { Id = Guid.NewGuid(), Title = "Echoes", Duration = 6.1, Year = 2022, Rating = 4.9, MusicianId = musicians[0].Id, Musician = musicians[0] },
                new Song { Id = Guid.NewGuid(), Title = "Blue Moods", Duration = 3.9, Year = 2019, Rating = 3.7, MusicianId = musicians[1].Id, Musician = musicians[1] },
            };
    }
}