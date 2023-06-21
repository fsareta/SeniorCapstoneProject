using Microsoft.AspNetCore.Mvc;
using SeniorCapstoneProject.Data;

namespace SeniorCapstoneProject.Controllers
{
    public class ScoreController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public ScoreController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Details(int id)
        {
            //detailed report of student progress
            return View(); 
        }
    }
}
