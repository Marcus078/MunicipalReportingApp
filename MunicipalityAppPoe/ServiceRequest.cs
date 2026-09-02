using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityAppPoe
{
    public class ServiceRequest
    {
        public string RequestID { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime DateReported { get; set; }

        public ServiceRequest(string location, string category, string description, string filePath)
        {
            RequestID = "REQ-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Location = location;
            Category = category;
            Description = description;
            FilePath = string.IsNullOrWhiteSpace(filePath) ? "No Attachment" : filePath;
            DateReported = DateTime.Now;
        }
    }
}
