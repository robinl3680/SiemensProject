using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiThreadDownload.Library;
namespace User
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> displays = new Dictionary<string, double>();

        public void GetExceptionMessage(string message)
        {
            MessageBox.Show(message);
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("File Name", "File Name");
            dataGridView1.Columns.Add("KBytes", "KBytes");
            dataGridView1.Columns.Add("Thread ID", "Thread ID");
            
        }
       public void print(string name,double totalbytes, int threadId)
        {
            totalbytes = totalbytes / 1024;
            totalbytes = Math.Ceiling(totalbytes);

            //MessageBox.Show($"{name} : {totalbytes}");
            try
            {
                dataGridView1.Rows.Add(name, totalbytes, threadId);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] urls = new string[] { "https://file-examples.com/wp-content/uploads/2017/10/file_example_ODP_1MB.odp",
        "http://www.quintic.com/software/sample_videos/AutoTracking_CyclingFV70rpm.avi",
        "http://www.quintic.com/software/sample_videos/AutoTracking_CyclingSV70rpm.avi",
        "http://www.quintic.com/software/sample_videos/Golf_Putting_AutoTracking.avi",
            "https://file-examples.com/wp-content/uploads/2018/04/file_example_AVI_1920_2_3MG.avi",
            "https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1280_10MG.mp4",
            "https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_5MG.mp3",
            "https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_2MG.mp3",
            "https://file-examples.com/wp-content/uploads/2017/02/file-sample_500kB.docx",
            "http://mirrors.standaloneinstaller.com/video-sample/DLP_PART_2_768k.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/video-sample.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/grb_2.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/TRA3106.m4v",
            "http://mirrors.standaloneinstaller.com/video-sample/lion-sample.avi",
            "http://mirrors.standaloneinstaller.com/video-sample/page18-movie-4.avi"};
            message m = print;
            exceptionMessage exceptionMessage = this.GetExceptionMessage;
            Helper h = new Helper(m, exceptionMessage);
            
            try
            {
                foreach (string url in urls)
                {
                    h.InsertToQueue(url);
                }
                h.StartDownload();
            }
            catch (UrlNotWellFormedException ex)
            {
                exceptionMessage(ex.ToString());
            }
            catch (WebException ex)
            {
                exceptionMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                exceptionMessage(ex.ToString());
            }

        }

       
    }
}
