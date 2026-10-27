using Microsoft.Extensions.Configuration;
using MusikApp;
// Läser inställningar från appsettings.json (samma sätt som i hero_databas).
// Databasens sökväg ligger där, så du slipper skriva den i koden.
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Hittar ingen connection string 'Default' i appsettings.json.");

var db = new DbHandler(connectionString);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Greta Van Fleet ===");
    Console.WriteLine("1. Visa alla låtar");
    Console.WriteLine("2. Sök låt");
    Console.WriteLine("3. Visa detaljer");
    Console.WriteLine("4. Avsluta");
    Console.Write("Välj: ");

    string? val = Console.ReadLine();

    switch (val)
    {
        case "1":
            var allSongs = db.GetAllSongs();
            foreach (var song in allSongs)
            {
             Console.WriteLine($"{song.Id}. {song.Title} ({song.DurationSeconds} sek");
            }
            
            break;
        
        case "2":
            Console.Write("Sök efter: ");
            string sokord = Console.ReadLine() ?? "";

            var hits = db.SearchSongs(sokord);
            if (hits.Count == 0)
            {
                Console.WriteLine("Inga låtar hittades");
            }
            foreach (var song in hits)
            {
                Console.WriteLine($"{song.Id}. {song.Title} ({song.DurationSeconds} sek)");
            }
            break;
        case "3":
            Console.Write("Ange låtens id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Du måste skriva ett nummer");
                break;
            }

            var found = db.GetSongById(id);
            if (found == null)
            {
                Console.WriteLine("Ingen låt med det id:t hittades");
            }
            else
            {
                Console.WriteLine($"Titel:      {found.Title}");
                Console.WriteLine($"Längd:      {found.DurationSeconds} sek");
                Console.WriteLine($"Spår nr:    {found.TrackNumber}");
                Console.WriteLine($"Album-id:   {found.AlbumId}");
            }
            break;
        case "4":
            Console.WriteLine("Avsluta program");
            return;
        default:
            Console.WriteLine("Ogiltigt val, välj 1-4");
            break;
    }
}


