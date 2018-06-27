using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Models;
using HangWeb.Service;

namespace HangWeb.Controllers
{
    public class MakeQuestionController : Controller
    {        
        public ActionResult Index()
        {
            if (Session["IDUser"] == null)
            {
                return Redirect("/Home/Index?invalid");
            }
            Questions question = new Questions();
            question.QuestionBy = (int)Session["IDUser"];
                        
            return View(question);
        }        
        
        public ActionResult InsertQuestion(Questions questions)
        {
            if (ModelState.IsValid == true)
            {
                questions.Answer = questions.Answer.ToUpper();

                questions.Answer = questions.Answer.Trim();
                questions.Question = questions.Question.Trim();

                bool result = new MakeQuestionService().InsertQuestion(questions);
                if (result == true)
                {
                    return Redirect("/MakeQuestion/Index?insertQuestionSuccess");
                }
                else
                {
                    return Redirect("/MakeQuestion/Index?insertQuestionFailed");
                }
            }
            
            return View("Index", questions);
        }
    }
}