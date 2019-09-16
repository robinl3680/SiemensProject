using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MultiThreadDownloader;
namespace UserInterfaceConsole
{
    class Program
    {
        static void DisplayDetails(DisplayClass disp)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            dict[disp.FileName] = disp.ByteReceived;
            foreach (KeyValuePair<string, double> items in dict)
            {
                Console.WriteLine($"{items.Key} : {items.Value}");
            }
        }
        static void DonwloadComp(string disp)
        {
            //Console.WriteLine($"{disp} Completed");
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
            DownloadHelper downloader;
            IntenetSlow e = ErrorHandle;
            List<Task> tasks = new List<Task>();
            
                Task t;
                foreach (string url in urls)
                {
                    downloader = new DownloadHelper();
                    t = downloader.DownloadHelperDownloadAsync(url, h, d, e);
                    tasks.Add(t);

                }
            Task.WaitAll(tasks.ToArray());

        }
    }
}
