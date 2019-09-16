using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownloader
{
    public delegate void HelperDownload(FileInfo[]files);
    public delegate void DownloadComplete(string fileName);
    public delegate void IntenetSlow(string message);
    public class DisplayClass
    {
        public string FileName { get; set; }
        public double ByteReceived { get; set; }
        public int PercentageCompleted { get; set; }
        public DisplayClass()
        {

        }
        public DisplayClass(string name, double bytesto, int percentage)
        {
            this.ByteReceived = bytesto;
            this.FileName = name;
            this.PercentageCompleted = percentage;
        }
    }
}
