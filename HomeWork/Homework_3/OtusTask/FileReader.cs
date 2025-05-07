namespace OtusTask;

public class FileReader
{
    public Task<string> ReadTextAsync(string filePath) => File.ReadAllTextAsync(filePath);
}