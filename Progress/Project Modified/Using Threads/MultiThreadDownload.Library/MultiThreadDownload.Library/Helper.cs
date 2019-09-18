using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;

namespace MultiThreadDownload.Library
{
    public class UrlNotWellFormedException : Exception {
        public UrlNotWellFormedException(string message) : base(message)
        {
            
        }
    }


    public delegate void message(string name,double bytes, int threadId);
    public delegate void exceptionMessage(string message);
    public class Helper
    {
        Mutex mutex;
        Queue<string> urls;
        List<Thread> threads;
        message m;
        exceptionMessage message;
        //public void CreateThread()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        ParameterizedThreadStart threadDelegate =
        //        new ParameterizedThreadStart((obj) => DownloadUsingThread(obj, m));
        //        Thread t = new Thread(threadDelegate);
        //        threads.Add(t);
        //    }
        //}
        public Helper(message m, exceptionMessage message)
        {
            
            mutex = new Mutex();
            this.m = m;
            this.message = message;
            urls = new Queue<string>();
            threads = new List<Thread>();
           // CreateThread();
        }
        public Helper(Queue<string> urls)
        {
            this.urls = urls;
        }

        public void StartDownload()
        {
            //ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);
            foreach(string url in urls)
            {
               
                mutex.WaitOne();
                ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadUsingThread), url);
                mutex.ReleaseMutex();
            }
            
        }

        public void InsertToQueue(string url)
        {
            urls.Enqueue(url);
            
            
        }

        public void DownloadFile(string url,message m)
        {
            string fname = null;
            try
            {
                    if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                    {
                    WebClient client = new WebClient();
                    string[] parts = url.ToString().Split('/');
                    fname = parts.Last();
                    NetworkChange.NetworkAvailabilityChanged += (sx, ex) => AvailabilityChanged(sx, ex, message, fname);
                    List<byte> buffer = new List<byte>();
                    byte[] temp = buffer.ToArray();
                    temp = client.DownloadData(url);
                    double totalSizeBytes = Convert.ToDouble(client.ResponseHeaders["Content-Length"]);

                        Thread thread = Thread.CurrentThread;
                        int tid = thread.ManagedThreadId;
                    
                        if (temp.Length == Convert.ToInt32(totalSizeBytes))
                        {
                            m(fname, totalSizeBytes, tid);
                            File.WriteAllBytes($"{ConfigurationManager.AppSettings["FILE_PATH"]}\\{fname}", temp);
                        }
                    
                    
                }
                else
                {
                    throw new UrlNotWellFormedException("");
                }
            }
            catch (UrlNotWellFormedException)
            {
                message(url + ": URL is not correct");
            }
            catch (WebException)
            {
                message(fname + " DownloadFile failed");
            }
            catch (Exception)
            {
                message("Download file method Exception Occured");
            }
        }

        private void AvailabilityChanged(object sx, NetworkAvailabilityEventArgs ex, exceptionMessage s, object fileName)
        {
            if(!ex.IsAvailable)
            {
                s($"{fileName.ToString()} : Connection lost");
            }
            else
            {
                s($"{fileName.ToString()} : Connection established");
            }
        }



        //public void DownloadStart()
        //{
        //    while(true)
        //    {
        //        foreach (var thread in threads)
        //        {
        //            if (!thread.IsAlive)
        //            {
        //                if (urls.Count > 0)
        //                {
        //                    mutex.WaitOne();
        //                    thread.Start(urls.First());
        //                    urls.Dequeue();
        //                    mutex.ReleaseMutex();
        //                }
        //                else
        //                {
        //                    return;
        //                }

        //            }


        //        }

        //        threads.Clear();
        //       // CreateThread();

        //    }

        //}
        public void DownloadUsingThread(object url)
        {
            try
            {
                DownloadFile(url.ToString(), m);
            }
            catch (Exception)
            {
                message("DownloadUsingThread class Exception occured");
            }
        }

    }
}
