namespace OtusTask;

public class FileFinder
{
    public Task<string[]> GetFilesAsync(string directory)
    {
        return Task.FromResult(Directory.GetFiles(directory));
    }
}