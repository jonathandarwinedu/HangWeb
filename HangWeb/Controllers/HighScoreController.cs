using HangWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Service;


namespace HangWeb.Controllers
{
    public class HighScoreController : Controller
    {       
        // GET: HighScore
        public ActionResult Index()
        {
            List<HighScore> listHighScore = new HighScoreService().getHighScoreList();            
            return View(listHighScore);
        }
    }
}