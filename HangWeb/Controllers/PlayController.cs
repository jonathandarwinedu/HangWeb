using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Models;
using HangWeb.Service;

namespace HangWeb.Controllers
{
    public class PlayController : Controller
    {
        // GET: Play
        public ActionResult Index(int IDQuestion)
        {
            Questions question = new PlayService().getQuestionByIDQuestion(IDQuestion);

            if(question != null)
            {
                return View(question);
            }
            else
            {
                return Redirect("/Home/Index?error");
            }
            
        }

        public ActionResult Done(Questions questions, int Status)
        {
            int point = 0;
            if (Status == 1)
            {
                questions.AnsweredBy = (int)Session["IDUser"];

                // SUDAH DIJAWAB
                questions.Status = 2;

                
                switch (questions.Difficulty)
                {
                    case 1:
                        point = (int)Session["Point"] + 10;
                        break;
                    case 2:
                        point = (int)Session["Point"] + 30;
                        break;
                    case 3:
                        point = (int)Session["Point"] + 50;
                        break;
                }

                // UPDATE SESSION POINT
                Session["Point"] = point;

                bool result = new PlayService().UpdateQuestion(questions);
                bool result2 = new PlayService().UpdateUser((int)questions.AnsweredBy, point);
                if (result == true && result2 == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect("/Home/Index?updateQuestionFailed");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            
            
            
        }
    }
}