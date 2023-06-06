using Microsoft.AspNetCore.Mvc;
using SeniorCapstoneProject.Services;

namespace SeniorCapstoneProject.Controllers
{
    public class LevelController: Controller
    {
        IQuestions _questions;
    public LevelController(IQuestions questions)
        {
            _questions = questions;
        }
        public IActionResult Game()
        {
            
            return View();
        }
        public IActionResult DetailedReport()
        {
            return View();
        }
    }
}
