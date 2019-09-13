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
        static void DisplayDetails(DisplayClass disp)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            dict[disp.FileName] = disp.ByteReceived;
            foreach(KeyValuePair<string,double> items in dict)
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
            MultiThreadDownloader downloader;
            IntenetSlow e = ErrorHandle;
            
            while(true)
            {
               
                foreach (string url in urls)
                {
                    downloader = new MultiThreadDownloader();
                    downloader.DownloadHelperDownloadAsync(url, h, d, e);
                    
                }
                
            }
            
        }
    }
}
