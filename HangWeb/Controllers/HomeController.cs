using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Models;
using HangWeb.Service;

namespace HangWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Level = "Easy";
            return View();
        }        

        public ActionResult _Difficulty(int difficulty)
        {
            List<Questions> questions = new List<Questions>();
            if (Session["IDUser"] != null)
            {
                // GET QUESTIONS BY DIFFICULTY AND IDUSER AGAR USER YANG SEDANG LOGIN
                // TIDAK MENJAWAB PERTANYAAAN DARI DIA SENDIRI
                questions = new HomeService().getAllQuestionsByIDUserAndDifficulty((int)Session["IDUser"], difficulty);
            }
            else
            {
                // GET ALL QUESTIONS TANPA MELIHAT IDUSER KARENA BLM LOGIN
                questions = new HomeService().getAllQuestionsByDifficulty(difficulty);
            }

            switch (difficulty)
            {
                case 1:
                    ViewBag.header = "Easy";
                    break;
                case 2:
                    ViewBag.header = "Medium";
                    break;
                case 3:
                    ViewBag.header = "Hard";
                    break;
            }// END OF SWITCH CASE

            return PartialView(questions);
        }

        public ActionResult redirectingToPlayController()
        {

            return RedirectToAction("Index", "Play");
        }

    }
}