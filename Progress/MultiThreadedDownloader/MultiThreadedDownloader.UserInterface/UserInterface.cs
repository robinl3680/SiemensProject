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
using System.Net;
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
        //public void UpdateProgress(string fileName,double x,int y)
        //{
        //    displays[fileName] = x;
        //    if(dataGridView1.Rows.Count > 1)
        //    {
        //        foreach(DataGridViewRow row in dataGridView1.Rows)
        //        {
        //            if(row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
        //            {
        //                if(displays.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == fileName)
        //                {
        //                    row.Cells[1].Value = x;
        //                    row.Cells[2].Value = $"{y}%";
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                dataGridView1.Rows.Add(fileName, x);
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        dataGridView1.Rows.Add(fileName,x);
        //    }
        //}

        public void UpdateProgress(DisplayClass displayProgress)
        {
            displays[displayProgress.FileName] = displayProgress.ByteReceived;
            
            if (dataGridView1.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != String.Empty)
                    {
                        if (displays.ContainsKey(row.Cells[0].Value.ToString()) && row.Cells[0].Value.ToString() == displayProgress.FileName)
                        {
                            row.Cells[1].Value = displayProgress.ByteReceived;
                            row.Cells[2].Value = $"{displayProgress.PercentageCompleted}%";
                            break;
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add(displayProgress.FileName, displayProgress.ByteReceived);
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(displayProgress.FileName, displayProgress.ByteReceived);
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
        private  void Btn_download_ClickAsync(object sender, EventArgs e)
        {
            string url = txt_url.Text;
            downloader = new MultiThreadDownloader();
           
            HelperDownload h = this.UpdateProgress;
            DownloadComplete d = this.DisplayMessage;
            IntenetSlow slow = this.PrintMessage;
            string[] urls = { "https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1280_10MG.mp4",
                "https://file-examples.com/wp-content/uploads/2017/10/file_example_ODP_1MB.odp",
                "http://www.quintic.com/software/sample_videos/AutoTracking_CyclingFV90rpm.avi"};

            try
            {
                Task t = null;
                //foreach (string url1 in urls)
                //{
                //      t = downloader.DownloadHelperDownloadAsync(url1, h, d, slow);

                //}



                t = downloader.DownloadHelperDownloadAsync(url, h, d, slow);


            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Txt_url_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
