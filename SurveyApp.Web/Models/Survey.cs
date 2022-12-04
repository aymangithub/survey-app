using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
    public class License
    {
        public int Id { get; set; }

        public string LicenseId { get; set; }

        public string LicenseType { get; set; }

        public string BuildingType { get; set; }

        public string BaladiaName { get; set; }

        public string LicenseDateHijri { get; set; }

        public string LicenseEndDateHijri { get; set; }
        public string AddressHai { get; set; }
        public string NationalIdentityNumber { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string LicenseIdEncrypted { get; set; }


    }
}
