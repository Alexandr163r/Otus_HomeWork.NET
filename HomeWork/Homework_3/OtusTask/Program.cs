using OtusTask;

//Оставил вызов прошлого ассинхронного варианта.   
// if (string.IsNullOrWhiteSpace(directoryFiles))
// {
//     Console.WriteLine("Путь к директории не может быть пустым!");
//     return;
// }
//
// var txtSpaceCounter = new TxtSpaceCounter();
// await txtSpaceCounter.CountSpacesInDirectoryAsynс(directoryFiles);

var directoryFiles = Console.ReadLine();

if (directoryFiles != null)
{
    var reader = new ParallelFileReader();
    reader.ReadAllFilesInDirectory(directoryFiles);
    Console.ReadKey();
}
else
{
    Console.WriteLine("Не передана дериктория с файлами");
}


