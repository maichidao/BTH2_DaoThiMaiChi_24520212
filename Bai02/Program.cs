using System.Globalization;

namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap duong dan thu muc (vi du: C:\\, D:\\Folder): ");
            string path = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Duong dan khong hop le hoac thu muc khong ton tai.");
                return;
            }

            Console.Write("Liet ke tat ca thu muc con? (y/n): ");
            string ans = Console.ReadLine()?.Trim().ToLower();
            bool recursive = (ans == "y" || ans == "yes");

            Console.WriteLine();
            try
            {
                Console.WriteLine($" Directory of {Path.GetFullPath(path)}");
                Console.WriteLine();

                long totalFiles = 0;
                long totalBytes = 0;
                long totalDirs = 0;

                ListDirectory(path, recursive, ref totalDirs, ref totalFiles, ref totalBytes, 0);

                Console.WriteLine();
                Console.WriteLine($"     {totalFiles} File(s)".PadRight(40) + $"{FormatBytes(totalBytes)} bytes");
                Console.WriteLine($"     {totalDirs} Dir(s)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi truy xuat thu muc: " + ex.Message);
            }
        }

        static void ListDirectory(string path, bool recursive, ref long totalDirs, ref long totalFiles, ref long totalBytes, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 0);
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            DirectoryInfo[] subDirs;
            FileInfo[] files;
            try
            {
                subDirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"{indent}Khong co quyen truy cap thu muc: {path}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{indent}Loi khi doc thu muc: {ex.Message}");
                return;
            }

            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"{indent}Khong co quyen truy cap file trong: {path}");
                files = new FileInfo[0];
            }

            foreach (var d in subDirs)
            {
                Console.WriteLine($"{indent}{d.LastWriteTime.ToString("dd/MM/yyyy  hh:mm tt", CultureInfo.InvariantCulture)}    <DIR>           {d.Name}");
                totalDirs++;
            }

            foreach (var f in files)
            {
                Console.WriteLine($"{indent}{f.LastWriteTime.ToString("dd/MM/yyyy  hh:mm tt", CultureInfo.InvariantCulture)}    {f.Length,15:N0} {f.Name}");
                totalFiles++;
                totalBytes += f.Length;
            }

            if (recursive)
            {
                foreach (var d in subDirs)
                {
                    ListDirectory(d.FullName, recursive, ref totalDirs, ref totalFiles, ref totalBytes, indentLevel + 1);
                }
            }
        }
    

        static string FormatBytes(long bytes)
        {
            return bytes.ToString("N0", CultureInfo.InvariantCulture);
        }
    }
}
