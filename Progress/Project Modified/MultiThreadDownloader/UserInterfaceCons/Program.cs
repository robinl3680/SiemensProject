using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MultiThreadDownloader;
namespace UserInterfaceConsole
{
    class Program
    {
        static void DisplayDetails(FileInfo[] files)
        {
            foreach(var file in files)
            {
                Console.WriteLine($"{file.Name} : {file.Length}");
            }
        }
        static void DonwloadComp(string disp)
        {
            Console.WriteLine($"{disp} Completed");
        }
        static void ErrorHandle(string message)
        {

        }
        static void Main()
        {
            string fileName;
            fileName = Console.ReadLine();
            string[] urls = File.ReadAllLines(fileName);
            HelperDownload h = DisplayDetails;
            DownloadComplete d = DonwloadComp;
            DownloadHelper download = new DownloadHelper();
            IntenetSlow e = ErrorHandle;
            List<Task> tasks = new List<Task>();

            Task t = null;
            foreach (string url in urls)
            {

                t = download.DownloadHelperDownloadAsync(url);

               
                tasks.Add(t);

            }
            download.FileWatcher(h);
            Task.WaitAll(tasks.ToArray());

        }
    }
}