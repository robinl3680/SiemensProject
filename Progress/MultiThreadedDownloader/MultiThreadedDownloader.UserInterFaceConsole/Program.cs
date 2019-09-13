using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MultiThreadedDownloader.MultiDownloaderLibrary;
using System.IO;
using Supporter;
namespace MultiThreadedDownloader.UserInterFaceConsole
{
    public class Program
    {
        public static void DisplayDetails(string name,double x,int y)
        {

        }
        public static void Completed(string name)
        {

        }
        static void Main()
        {
            string path = Console.ReadLine();
            string[]urls = File.ReadAllLines(path);
            HelperDownload helper = DisplayDetails;
            DownloadComplete d = Completed;
        }
    }
}
