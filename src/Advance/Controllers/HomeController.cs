using Advance.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Advance.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ReportUrl = GetCognosReportUrlByReportGatewayService();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetCognosReportUrlByReportGatewayService()
        {
            string strReportUrl = string.Empty;
            string strReportGatewayURL = "https://esbstg.nycboe.net/appreporting/v1/ReportDataSync";
            string strReportGatewayServiceUserID = "Service.TPR";
            string strReportGatewayServicePassword = "82ARdz8";

            // call the ESB service
            if (strReportGatewayURL.Length > 0)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(strReportGatewayURL);

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
                                    ex.GetHashCode();

                                    if (obj.errors != null && obj.errors[0].Length > 0)
                                    {
                                        Console.WriteLine(obj.errors[0].ToString());
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
                    ex.GetHashCode();
                }
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
            model.reportParameters = "[{ LocationCode:M300 }]";
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