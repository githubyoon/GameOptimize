namespace GameOptimizeInstaller;

internal static class Program
{
    // 1. Rider 규칙 반영: private static readonly는 PascalCase (GoDir)
    private static readonly string GoDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "GameOptimize"
    );

    // 2. 소켓 고갈 방지: HttpClient를 static으로 선언하여 앱 실행 동안 재사용
    private static readonly HttpClient Client = new();

    public static async Task Main(string[] args)
    {
        try
        {
            if (!Directory.Exists(GoDir))
            {
                Directory.CreateDirectory(GoDir);
            }

            // 파일 정보 설정
            const string fileUrl = ""; 
            string savePath = Path.Combine(GoDir, "GameOptimize.exe");

            Console.WriteLine("다운로드 시작...");
            
            // 3. static Client를 사용하여 다운로드
            byte[] data = await Client.GetByteArrayAsync(fileUrl);
            await File.WriteAllBytesAsync(savePath, data);
            
            Console.WriteLine($"성공! 저장 위치: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
        }
    }
}