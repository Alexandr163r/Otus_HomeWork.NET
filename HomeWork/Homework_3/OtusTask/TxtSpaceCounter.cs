namespace OtusTask;

public class TxtSpaceCounter
{
    private readonly FileFinder _fileFinder;
    private readonly FileReader _fileReader;
    private readonly SpaceCounter _spaceCounter;

    public TxtSpaceCounter()
    {
        _fileFinder = new FileFinder();
        _fileReader = new FileReader();
        _spaceCounter = new SpaceCounter();
    }

    public async Task CountSpacesInDirectoryAsynс(string directoryPath)
    {
        var files = await _fileFinder.GetFilesAsync(directoryPath);
        var spaceCountingTasks = files.Select(CountSpacesInFileAsync);
        var spaceCount= await Task.WhenAll(spaceCountingTasks);
        
        Console.WriteLine(
            $"Пробелы в файлах: {string.Join(", ", spaceCount)}.\n" +
            $"Всего пробелов: {spaceCount.Sum()} в {spaceCount.Count()} файлах."
        );
    }

    private async Task<int> CountSpacesInFileAsync(string filePath)
    {
        var text = _fileReader.ReadTextAsync(filePath);
        return await _spaceCounter.CountAsync(text);
    }
}