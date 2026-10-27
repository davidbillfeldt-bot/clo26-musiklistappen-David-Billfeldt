# Reflektion — Musiklistappen

**Namn:** [David Billfeldt]
**Datum:** [2026-10-27

---

## Vad var svårast?

[no such table: songs: databasen fanns, men appen läste en tom kopia i bin-mappen. Svårt att förstå eftersom koden var rätt.]

---

## Vad lärde du dig?

[Att en klass (Song) motsvarar en rad i tabellen, och en property en kolumn. Att dela upp koden i Program.cs (meny) och DbHandler.cs (databas). int.TryParse, ?? "", using var. Att läsa felmeddelanden: leta efter Error och radnumret.]

---

## Hur använde du ADO.NET i praktiken — vad kändes naturligt och vad var förvirrande?

Tänk på de fem stegen: öppna anslutning, skapa kommando, skriv SQL, skicka in värden, kör.

[Det som kändes naturligt var SQL delen då vi jobbat med det i diskografi uppgiften. När GetAllSongs fungerade var de andra metoderna samma mönster.Lite förvirrande var Varför using. Först förstod jag inte varför det stod using var framför anslutningen. Nu vet jag att det gör att anslutningen stängs automatiskt när metoden är klar. Utan den kan databasfilen förbli öppen och låst.]

---

## Varför ska man använda parameteriserade queries?

Vad kan hända om man klistrar ihop SQL med strängar i stället? (Tänk på Bobby Tables.)

[Med strängkonkatenering, "... LIKE '" + sokord + "'", blir användarens text en del av SQL-koden. Någon kan skriva något som '; DROP TABLE songs; -- och radera tabellen. Det är SQL-injection. Med @sok skickas texten separat som ett värde. Databasen behandlar den alltid som text, aldrig som kod.]

---

## Om du hade mer tid — vad hade du lagt till eller gjort annorlunda?

[Lägg till och ta bort låtar (med “Är du säker? j/n”), visa albumnamn i stället för album-id (det kräver en JOIN, som är VG-nivå)]

---

## (VG) Varför delade du upp koden som du gjorde?

Resonera kring ditt designval: varför ligger databaskoden i `DbHandler` och inte i `Program.cs`? Vad hade blivit svårare om allt låg i samma fil?

[Skriv här]
