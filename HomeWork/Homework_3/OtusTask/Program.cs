
using System.Diagnostics;
using OtusTask;

var stopwatch = Stopwatch.StartNew();
var baseDir = AppContext.BaseDirectory;
var derictoryFiles = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "Files"));

var txtSpaceCounter = new TxtSpaceCounter();
await txtSpaceCounter.CountSpacesInDirectoryAsynс(derictoryFiles);

Console.WriteLine($"Время выполнения {stopwatch.Elapsed}");
