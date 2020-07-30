﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Web.Models
{
	public class Survey
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public List<Question> Questions { get; set; }

		public List<FilledSurvey> FilledSurveys { get; set; }
	}
}
