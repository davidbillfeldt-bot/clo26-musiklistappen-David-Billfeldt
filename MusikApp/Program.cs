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
            Console.WriteLine("Sök ej tillagt än");
            break;
        case "3":
            Console.WriteLine("Visa detaljer ej tillagt än");
            break;
        case "4":
            Console.WriteLine("Avsluta program");
            return;
        default:
            Console.WriteLine("Ogiltigt val, välj 1-4");
            break;
    }
}

// Tips på ordning (se UPPGIFT.md):
//   1. Rita upp huvudmenyn (alternativ numrerade 1-N) och läs in ett val med Console.ReadLine().
//      Skriv ut "Här kommer en lista senare" tills databasen är kopplad.
//   2. Skapa ett DbHandler-objekt: new DbHandler(connectionString)
//   3. Anropa DbHandlers metoder från menyn. Här ska ALDRIG SQL stå.
//   4. Avsluta snyggt när användaren väljer "Avsluta".
