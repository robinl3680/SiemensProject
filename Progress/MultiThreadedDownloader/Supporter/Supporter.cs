using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter
{
    public delegate void HelperDownload(DisplayClass displayProgress);
    public delegate void DownloadComplete(string fileName);
    public delegate void IntenetSlow(string message);
    public class DisplayClass
    {
        public string FileName { get; set; }
        public double ByteReceived { get; set; }
        public int PercentageCompleted { get; set; }
        public double TotalBytes { get; set; }
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
