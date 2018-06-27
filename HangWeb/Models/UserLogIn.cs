using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HangWeb.Models
{
    public class UserLogIn
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please Fill Your Username")]
        public string Username { get; set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Fill Your Password")]
        public string Password { get; set; }
    }
}