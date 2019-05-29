namespace Pcf.Push.Dotnet.Core.Mvc.Windows.Models
{
    public class Application
    {
        public string application_id { get; set; }
        public string application_name { get; set; }
        public string[] application_uris { get; set; }
        public string application_version { get; set; }
        public string cf_api { get; set; }
        public string host { get; set; }
        public string instance_id { get; set; }
        public string instance_index { get; set; }
        public Limits limits { get; set; }
        public string name { get; set; }
        public string port { get; set; }
        public string space_id { get; set; }
        public string space_name { get; set; }
        public string[] uris { get; set; }
        public string version { get; set; }
    }
}