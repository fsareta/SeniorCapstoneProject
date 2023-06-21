using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorCapstoneProject.Data;
using SeniorCapstoneProject.Models;
using SeniorCapstoneProject.ViewModels;

namespace SeniorCapstoneProject.Controllers
{
    public class LevelController: Controller
    {
        //inject DbContext
            ApplicationDbContext _context;
            IWebHostEnvironment _environment;
        
    public LevelController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        

        }
        public IActionResult Index()
        {
            IEnumerable<Level> levels=_context.Levels;
            return View(levels);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            /**/
            if (id == 0)
            {
                return NotFound();
            }
            Level level = _context.Levels.SingleOrDefault(x => x.Id == id);
            StudentAnswer answer = _context.StudentAnswers.SingleOrDefault(x => x.Id == id);
            if (level== null)
            {
                return NotFound();
            }
            IEnumerable<QnA> equations=_context.QnAs.Where(x=> x.LevelId == id);
            IEnumerable<StudentAnswer> answers = _context.StudentAnswers.Where(x=>x.QnAId==id);
            GameVM model = new GameVM
            {
                Level=level,
                StudentAnswers = answers,
                Questions = equations
               
          
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult SaveAnswers(int questionId, string answer)
        {
           

            StudentAnswer answ = new StudentAnswer
            {
                StuAnswer = answer,
                QnAId = questionId
                
            };
            _context.Add(answer);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
            
            
        }
        
        
        public IActionResult Create()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult Create(Level level)
        {
            if (!ModelState.IsValid)
            {
                return View(level);
            }
             level.IsUnlocked = false;
            _context.Levels.Add(level);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
