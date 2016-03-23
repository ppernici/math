using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MathQuestions.Models.Abstract;
using MathQuestions.Models.Concrete;
using MathQuestions.Models;

using Ninject;

namespace MathQuestions.Controllers
{
    public class HomeController : Controller
    {
        IQuestionContainer container;

        public HomeController(IQuestionContainer container)
        {
            this.container = container;
        }
        public ActionResult Index()
        {
            return View(container);
        }

        [HttpGet]
        public ActionResult Submit()
        {
            bool[] answers = new bool[container.NumberOfQuestions];

            return View(answers);
        }
    }
}