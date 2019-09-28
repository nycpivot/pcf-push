using Advance.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Advance.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController()
        //{
        //    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() //F5
        {
            ViewBag.ReportUrl = GetCognosReportUrlByReportGatewayService("http://localhost:53401/Home/Input?q=werwer");
                //"https://esbstg.nycboe.net/appreporting/v1/ReportDataSync");

            return View();
        }

        public IActionResult Contact() //DIRECT
        {
            ViewBag.ReportUrl = GetCognosReportUrlByReportGatewayService(
                "http://mtsapplx02.c3ntral.nyc3d.0rg:7800/appreporting/v1/ReportDataSync");

            return View();
        }


        public void Input(string q)
        {
            //HttpContext.Request
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetCognosReportUrlByReportGatewayService(string url)
        {
            string strReportUrl = string.Empty;
            string strReportGatewayURL = url;
            string strReportGatewayServiceUserID = "Service.TPR";
            string strReportGatewayServicePassword = "82ARdz8";


            // call the ESB service
            if (strReportGatewayURL.Length > 0)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(strReportGatewayURL);
                webRequest.Proxy = new WebProxy("http://127.0.0.1:8888");

                if (strReportGatewayServiceUserID.Length > 0 && strReportGatewayServicePassword.Length > 0)
                {
                    webRequest.Credentials = new NetworkCredential(strReportGatewayServiceUserID, strReportGatewayServicePassword);
                }

                ReportRequest model = GetReportRequestData();

                var dataToSend = JsonConvert.SerializeObject(model);

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.ContentType = "application/json";
                        webRequest.ContentLength = dataToSend.Length;
                        webRequest.Method = "POST";

                        using (Stream s = webRequest.GetRequestStream())
                        {
                            using (StreamWriter sw = new StreamWriter(s))
                            {
                                sw.Write(dataToSend);
                                sw.Close();
                            }

                           
                            s.Close();
                        }


                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                string strResult = sr.ReadToEnd();

                                ReportResponse obj = null;

                                try
                                {
                                    obj = JsonConvert.DeserializeObject<ReportResponse>(strResult);

                                    strReportUrl = obj.url;
                                }
                                catch (Exception ex)
                                {
                                    strReportUrl = ex.ToString();

                                    ex.GetHashCode();

                                    if (obj.errors != null && obj.errors[0].Length > 0)
                                    {
                                        Console.WriteLine("INNER ERROR: " + obj.errors[0].ToString());
                                    }
                                }

                                sr.Close();
                            }

                            s.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    strReportUrl = ex.ToString();
                    Console.WriteLine("OUTER ERROR: " + ex.ToString());
                    //ex.GetHashCode();
                }
            }

            if(String.IsNullOrWhiteSpace(strReportUrl))
            {
                strReportUrl = "EMPTY";
            }

            return strReportUrl;
        }

        private ReportRequest GetReportRequestData()
        {
            ReportRequest model = new ReportRequest();
            
            string strReportFormat = "PDF";
            string strReportParams = "[]";
            string strReportViewerOn = "Y";

            model.guid = "BC96E3BE-FB3F-434C-BC17-E44087CFE555";

            model.reportName = "SchoolReportExecutiveSummary"; // Session["sReportName"].ToString().Trim();

            model.reportOutputFormat = strReportFormat;
            model.reportParameters = "[{'LocationCode': 'M300'}]"; // "[{ LocationCode:M300 }]";
            model.reportMode = "sync";
            model.reportType = "Cognos";
            model.reportViewerOn = true;
            model.userName = "pcf_user";
            model.source = "web";
            model.runAtPrompt = false;

            // for troubleshooting purpose
            model.serverName = "pivotal cloud";
            model.requestUrl = "some url string";
            model.userAgent = "some user agent string";

            return model;
        }

        [Serializable]
        public class ReportRequest
        {
            public bool RETRYFLAG { get; set; }
            public string guid { get; set; }
            public string reportMode { get; set; }
            public string reportType { get; set; }
            public bool reportViewerOn { get; set; }
            public string reportName { get; set; }
            public string reportParameters { get; set; }
            public string reportOutputFormat { get; set; }
            public string userName { get; set; }
            public string source { get; set; }
            public string serverName { get; set; }
            public string requestUrl { get; set; }      
            public string userAgent { get; set; }
            public bool runAtPrompt { get; set; }
        }

        [Serializable]
        public class ReportResponse
        {
            public string guid { get; private set; }
            public string url { get; set; }
            public string[] errors { get; set; }
            public bool retry { get; set; }
            public string scheduleJobID { get; set; }
            public object scheduleJobStatus { get; set; }

            public ReportResponse(string guid)
            {
                this.guid = guid;
            }
        }
    }
}