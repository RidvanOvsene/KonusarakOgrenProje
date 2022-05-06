using KonusarakOgrenProje.Data;
using KonusarakOgrenProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace KonusarakOgrenProje.Controllers
{
    public class ExamController : Controller
    {
        private readonly DataContext _context;
        public List<Questions> QuestionsList;
        public ExamController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Questions(int ExamId)
        {
            var Exam = _context.Exams.ToList();
            var Questions = _context.Questions.Where(x => x.ExamId == ExamId).ToList();
            ViewBag.Subject = Exam;
            return View(Questions);
        }
        [Authorize]
        [HttpGet]
        public IActionResult QuestionsCreate()
        {
            var Exams = _context.Exams.ToList();
            ViewBag.Exams = Exams;
            return View();
        }
        [HttpPost]
        public IActionResult QuestionsCreate(IFormCollection collection)
        {
            for (int i = 1; i <= 4; i++)
            {
                var questions = new Questions();
                questions.ExamId = Convert.ToInt32(collection["ExamId"]);
                questions.Question = collection["Question_" + i];
                questions.ChoiceA = collection["ChoiceA_" + i];
                questions.ChoiceB = collection["ChoiceB_" + i];
                questions.ChoiceC = collection["ChoiceC_" + i];
                questions.ChoiceD = collection["ChoiceD_" + i];
                questions.Reply = collection["Reply_" + i];

                _context.Questions.Add(questions);
                _context.SaveChanges();
            }
            return RedirectToAction("Questions");
        }
        [Authorize]
        public IActionResult ExamList()
        {
            var Data = _context.Exams.ToList();
            return View(Data);

        }
        public JsonResult ExamDelete(string ExamId)
        {
            if (!string.IsNullOrEmpty(ExamId))
            {
                var data = _context.Exams.Find(Convert.ToInt32(ExamId));
                _context.Exams.Remove(data);
                _context.SaveChanges();
            }
            return Json("");
        }
        public JsonResult SaveChoice(string Answer)
        {
            if (!string.IsNullOrEmpty(Answer))
            {
                string[] Split = Answer.Split('_');
                if (Split.Count() == 2)
                {
                    var data = _context.Questions.Find(Convert.ToInt32(Split[0]));
                    data.Answer = Split[1];
                    _context.Questions.Update(data);
                    _context.SaveChanges();
                }
            }
            return Json("");
        }
        public JsonResult ComplateExam(string ExamId)
        {
            if (!string.IsNullOrEmpty(ExamId))
            {
                var data = _context.Questions.Where(x => x.ExamId == Convert.ToInt32(ExamId));
                return Json(data);
            }
            return Json("");
        }
    }
}
