namespace costcollector.Infrastructure.TokenReaders;

public static class TokenReader
{
    public static string GetToken()
    {
        var path = @"D:\downloads";
        var dir = new DirectoryInfo(path);
        var fileInfos = dir.EnumerateFiles("token*.txt").ToArray();
        var newestFile = fileInfos.MaxBy(f => f.CreationTime);
        return File.ReadAllText(newestFile!.FullName)
            .Replace(Environment.NewLine, string.Empty);
    }
}