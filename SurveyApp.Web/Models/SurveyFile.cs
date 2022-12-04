using System;

namespace SurveyApp.Web.Models
{
    public class SurveyFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string    LicenseId { get; set; }
        public DateTime CreationDatetime { get; set; } = DateTime.Now;
    }
}
