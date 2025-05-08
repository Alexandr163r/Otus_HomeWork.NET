
using System.Diagnostics;
using OtusTask;

var stopwatch = Stopwatch.StartNew();
var derictoryFiles = Console.ReadLine();

var txtSpaceCounter = new TxtSpaceCounter();
await txtSpaceCounter.CountSpacesInDirectoryAsynс(derictoryFiles);

Console.WriteLine($"Время выполнения {stopwatch.Elapsed}");
