using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HangWeb.Models
{
    public class Questions
    {
        public int IDQuestion { get; set; }
        public int QuestionBy { get; set; }
        [Required(ErrorMessage ="Please Input Your Question")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Please Input Your Answer")]
        public string Answer { get; set; }
        public int Difficulty { get; set; }
        public int Status { get; set; }
        public int? AnsweredBy { get; set; }
        public string NameQuestionBy { get; set; }
    }
}