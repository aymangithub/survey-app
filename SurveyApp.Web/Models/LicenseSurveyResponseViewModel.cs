using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace SurveyApp.Web.Models
{
    public class LicenseSurveyResponse
    {
        public int Id { get; set; }
        public string LicenseId { get; set; }

        public string Question1ResponseValue { get; set; }
        public string Question2ResponseValue { get; set; }
        public DateTime ResponseDate { get; set; } = DateAndTime.Now;
    }
}
