using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Configuration;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;

namespace MultiThreadDownloader
{
    public class DownloadHelper
    {
        public async Task DownloadHelperDownloadAsync(string url)
        {
           // DisplayClass disp = null;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Task t;

                WebClient client = new WebClient();
                string[] fileParts = url.Split('/');
                string fileName = fileParts.Last();

                Uri urlDownload = new Uri(url, UriKind.Absolute);

                DisplayClass disp = new DisplayClass();
                disp.FileName = fileName;
                await Task.Run(()=>client.DownloadFile(urlDownload, $"{ConfigurationManager.AppSettings["FILE_PATH"]}\\{fileName}"));


                //NetworkChange.NetworkAvailabilityChanged += (sx, ex) => AvailabilityChanged(sx, ex, s, fileName);

               

            }




        }
        public void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e, IntenetSlow s, string filename)
        {
            if (e.IsAvailable)
            {
                s($"Connection Established : {filename}");
            }
            else
            {
                s($"Connection Not Available : {filename}");
            }
        }
        

        public void FileWatcher(HelperDownload h)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = ConfigurationManager.AppSettings["FILE_PATH"];
            watcher.NotifyFilter = NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite
                             | NotifyFilters.FileName
                             | NotifyFilters.DirectoryName
                              | NotifyFilters.Size;

            // Only watch text files.
            //watcher.Filter = "*.txt";

            // Add event handlers.

            watcher.Changed += ((sender,x)=>UpdateProgress(h));
            watcher.Created += ((sender, x) => UpdateProgress(h));
            //watcher.Deleted += OnChanged;
            //watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private void UpdateProgress(HelperDownload h)
        {
            DirectoryInfo dir = new DirectoryInfo($"{ConfigurationManager.AppSettings["FILE_PATH"]}");
            FileInfo[] files = dir.GetFiles();
            h(files);
        }
    }
}
