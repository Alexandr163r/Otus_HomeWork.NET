namespace OtusTask;

public class SpaceCounter
{
    public async Task<int> CountAsync(Task<string> textTask) => 
        (await textTask).Count(c => c == ' ');
}