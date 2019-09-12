using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using Supporter;
using System.IO;
namespace MultiThreadedDownloader.MultiDownloaderLibrary
{
    
    
    public class MultiThreadDownloader
    {
        
        
        public void DownloadHelperDownload(string url,HelperDownload h,DownloadComplete d)
        {
            
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                
                WebClient client = new WebClient();
                string[] fileParts = url.Split('/');
                string fileName = fileParts.Last();
             
                Uri urlDownload = new Uri(url, UriKind.Absolute);
                client.DownloadFileAsync(urlDownload, $"C:\\Users\\Robin R\\Documents\\{fileName}");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((send, ex) => Client_DownloadProgress(send, ex, fileName,h));
                client.DownloadFileCompleted += new AsyncCompletedEventHandler((send, ex) => Client_DownloadCompleted(send, ex, fileName,d));

           
             }
            
            
        }
        public void Client_DownloadProgress(object sender, DownloadProgressChangedEventArgs e, string fileName,HelperDownload h)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());

            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            h(fileName, double.Parse(e.BytesReceived.ToString()),int.Parse(Math.Truncate(percentage).ToString()));
            
        }
        private void Client_DownloadCompleted(object sender, AsyncCompletedEventArgs e, string fileName,DownloadComplete d)
        {
            d(fileName);
        }

    }
}
