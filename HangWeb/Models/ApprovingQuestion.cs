using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangWeb.Models
{
    public class ApprovingQuestion
    {
        public int IDQuestion { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string QuestionBy { get; set; }
        public int Difficulty { get; set; }
    }
}