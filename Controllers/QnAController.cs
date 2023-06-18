using Microsoft.AspNetCore.Mvc;
using SeniorCapstoneProject.Data;
using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.Controllers
{
    public class QnAController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public QnAController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            //view questions and answers per level
            IEnumerable<QnA> q = _context.QnAs;
            return View(q);
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QnA q)
        {
            if (!ModelState.IsValid)
            {
                return View(q);
            }
           
            _context.QnAs.Add(q);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
