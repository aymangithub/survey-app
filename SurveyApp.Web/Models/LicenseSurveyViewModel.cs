using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
    public class LicenseSurveyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "رقم الرخصة")]
        public string LicenseId { get; set; }
        [Display(Name = "اسم المواطن")]
        public string Name { get; set; }

        public string Question1Text { get; set; } = "هل تم البدء في أعمال البناء بالموقع ؟";
        public string Question2Text { get; set; } = "ما هي نسبة الانجاز حاليا لأعمال البناء ؟";

        public QuestionChoice[] Question1Choices { get; set; } =
        {
            new QuestionChoice { Text ="نعم",Value="yes" },
            new QuestionChoice { Text = "لا", Value = "no" }
        };
        public QuestionChoice[] Question2Choices { get; set; } = {

             new QuestionChoice { Text ="100%",Value="100" },
            new QuestionChoice { Text = "75%", Value = "75" },
             new QuestionChoice { Text ="50%",Value="50" },
            new QuestionChoice { Text = "25%", Value = "25" },
            new QuestionChoice { Text = "لم أبدأ بعد", Value = "0" }

         };

        public List<IFormFile> Files { get; set; }
        public List<FileViewModel> FilesViewModel { get; set; }

        [Required(ErrorMessage = "أجب من فضلك على السؤال الأول")]
        public string Question1ResponseValue { get; set; }
        [Required(ErrorMessage = "أجب من فضلك على السؤال الثاني")]

        public string Question2ResponseValue { get; set; }
        public bool LicenseHasResponseBefore { get; set; }

        //[Display(Name = "Title")]
        //[Required(ErrorMessage = "Title is required.")]
        //public string Title { get; set; }

        //[Display(Name = "Created At")]
        //public DateTime? CreatedAt { get; set; }

        //[Display(Name = "Updated At")]
        //public DateTime? UpdatedAt { get; set; }

        //[Display(Name = "Questions")]
        //public List<Question> Questions { get; set; }

        //[Display(Name = "Answers")]
        //public List<FilledSurvey> FilledSurveys { get; set; }
    }
    public class FileViewModel {

        public IFormFile FormFile { get; set; }
        public SurveyFile FileData { get; set; }
    }
    public class QuestionChoice
    {
        public string Text { get; set; }
        public string Value { get; set; }

    }
}
