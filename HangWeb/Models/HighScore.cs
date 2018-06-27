using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangWeb.Models
{
    public class HighScore
    {
        public int IDUser { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
    }
}