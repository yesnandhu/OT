using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OT.Models;
using OT.Services;
using System;
using System.Collections.Generic;

namespace OT.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IConfiguration _configuration;

        public QuestionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Start()
        {
            TempData["count"] = 0;
            TempData["totalPoints"] = 0;
            TempData["totalQuestions"] = 5;
            return View();
        }
        public IActionResult Index()
        {
            string strCount = TempData["count"].ToString();
            int count = Convert.ToInt32(strCount) + 1;
            TempData["count"] = count;
            List<questionsModel> oModel = new List<questionsModel>();
            string myDb1ConnectionString = _configuration.GetConnectionString("DBConnection");
            Questions obj = new Questions();
            oModel = obj.getQuestions(myDb1ConnectionString);
            TempData["CorrectAnswer"] = oModel[0].CorrectAns;
            return View(oModel);
        }

        public ActionResult Submit(questionsModel obj)
        {
            string selectedAnswer = string.Empty;

            string strCount = TempData["count"].ToString();
            int count = Convert.ToInt32(strCount);
           

            if (obj.Ans1 == "on") selectedAnswer = selectedAnswer + "1";
            if (obj.Ans2 == "on") selectedAnswer = selectedAnswer + "2";
            if (obj.Ans3 == "on") selectedAnswer = selectedAnswer + "3";
            if (obj.Ans4 == "on") selectedAnswer = selectedAnswer + "4";

            if (selectedAnswer == TempData["CorrectAnswer"].ToString())
            {
                string score = TempData["totalPoints"].ToString();

                int totalScore = Convert.ToInt32(score) + 1;

                TempData["totalPoints"] = totalScore;

            }

            if (count < Convert.ToInt32(TempData["totalQuestions"].ToString()))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Finish");
            }
            
        }

        public ActionResult Finish()
        {
            return View();
        }
    }
}