﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter
{
    public delegate void HelperDownload(string fileName, double x, int y);
    public delegate void DownloadComplete(string fileName);
    public class DisplayClass
    {
        public string FileName { get; set; }
        public double ByteReceived { get; set; }
        public DisplayClass()
        {

        }
        public DisplayClass(string name, double bytesto)
        {
            this.ByteReceived = bytesto;
            this.FileName = name;
        }
    }
}
