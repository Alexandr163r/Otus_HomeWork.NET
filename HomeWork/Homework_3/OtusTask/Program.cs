
using System.Diagnostics;
using OtusTask;

var stopwatch = Stopwatch.StartNew();
var directoryFiles = Console.ReadLine();

if (string.IsNullOrWhiteSpace(directoryFiles))
{
    Console.WriteLine("Путь к директории не может быть пустым!");
    return;
}

var txtSpaceCounter = new TxtSpaceCounter();
await txtSpaceCounter.CountSpacesInDirectoryAsynс(directoryFiles);
Console.WriteLine($"Время выполнения {stopwatch.Elapsed}");
