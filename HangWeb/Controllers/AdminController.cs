using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Service;
using HangWeb.Models;

namespace HangWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<ApprovingQuestion> questions = new AdminService().getAllNotAprrovedQuestions();
            return View(questions);
        }

        [HttpPost]
        public ActionResult UpdateQuestion(int IDQuestion, string Difficulty)
        {
            int level = 0;
            int status = 1;
            switch (Difficulty)
            {
                case "Easy":
                    level = 1;                    
                    break;
                case "Medium":
                    level = 2;
                    break;
                case "Hard":
                    level = 3;
                    break;
                case "Decline":
                    status=-1;
                    break;
            }// END OF SWITCH

            bool result = new AdminService().UpdateQuestion(IDQuestion,level,status);
            if (result == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");

        }
    }
}