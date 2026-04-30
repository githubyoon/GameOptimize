namespace GameOptimizeInstaller;

internal static class Program
{
    private static readonly string InstallDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "GameOptimize"
    );

    private static readonly HttpClient Client = new();

    public static async Task Main(string[] args)
    {
        try
        {
            Directory.CreateDirectory(InstallDir);

            const string downloadUrl = "https://api.github.com/repos/githubyoon/GameOptimize/releases/latest";
            string savePath = Path.Combine(InstallDir, "GameOptimize.exe");

            Console.WriteLine("Starting Download...");

            byte[] data = await Client.GetByteArrayAsync(downloadUrl);
            await File.WriteAllBytesAsync(savePath, data);

            Console.WriteLine($"Complete\n savePath: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}