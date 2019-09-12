using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MultiThreadedDownloader.MultiDownloaderLibrary;
using Supporter;
namespace MultiThreadedDownloader.UserInterface
{
    public partial class UserInterface : Form
    {
        MultiThreadDownloader downloader;
        Dictionary<string, double> displays = new Dictionary<string, double>();
        Dictionary<string, string> status = new Dictionary<string, string>();
        public UserInterface()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Bytes", "Bytes");
            dataGridView1.Columns.Add("Status", "Status");
        }
        public void UpdateProgress(string fileName,double x,int y)
        {
            //prgs_download.Value = y;
            //lbl_prgrs.Text = fileName;
            //DisplayClass display = new DisplayClass { FileName = fileName, ByteReceived = x };
            //List<DisplayClass> displays = new List<DisplayClass> { display };
            displays[fileName] = x;
            if(dataGridView1.Rows.Count > 1)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
                    {
                        if(displays.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == fileName)
                        {
                            row.Cells[1].Value = x;
                            row.Cells[2].Value = $"{y}%";
                            break;
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add(fileName, x);
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(fileName,x);
            }
        }
        public void PrintMessage(string message)
        {
            MessageBox.Show(message);
        }
        public void DisplayMessage(string fileName)
        {
            status[fileName] = "Completed";
            if (dataGridView1.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
                    {
                        if (status.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == fileName)
                        {

                            row.Cells[2].Value = status[fileName];
                            break;
                        }
                    }
                }
            }
        }
        private void Btn_download_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text;
            downloader = new MultiThreadDownloader();
            HelperDownload h = this.UpdateProgress;
            DownloadComplete d = this.DisplayMessage;
            IntenetSlow slow = this.DisplayMessage;
            downloader.DownloadHelperDownload(url,h,d,slow);
        }

        private void Txt_url_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
