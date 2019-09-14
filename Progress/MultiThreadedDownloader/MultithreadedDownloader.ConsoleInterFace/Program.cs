using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter;
using  MultiThreadedDownloader.MultiDownloaderLibrary;
using System.IO;
namespace MultithreadedDownloader.ConsoleInterFace
{
    class Program
    {
        static Dictionary<string, double> dict = new Dictionary<string, double>();
        static void DisplayDetails(DisplayClass disp)
        {
            
            dict[disp.FileName] = disp.ByteReceived;
            
                Console.WriteLine($"{disp.FileName} : {disp.ByteReceived}");
        }
        static void DonwloadComp(string disp)
        {
            Console.WriteLine($"{disp} : Completed");
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
            MultiThreadDownloader downloader;
            IntenetSlow e = ErrorHandle;
            Task t;
            int k = 0;
            List<Task> tasks = new List<Task>();
             
                foreach (string url in urls)
                {
                    downloader = new MultiThreadDownloader();
                    t = downloader.DownloadHelperDownloadAsync(url, h, d, e);
                   
                    tasks.Add(t);
                }
            //k++;


              Task.WaitAll(tasks.ToArray());

        }
    }
}
