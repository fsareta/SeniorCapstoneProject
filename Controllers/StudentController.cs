using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorCapstoneProject.Data;
using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _environment;
        public StudentController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _context.Students.Include(x => x.Teacher);
            return View(students);
           
        }
        //this endpoint will show student's profile that will include
        //personal info plus game reports
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            student.Teacher = _context.Teachers.SingleOrDefault(x => x.Id == student.TeacherId);
            student.Level=_context.Levels.SingleOrDefault(x => x.Id == student.LevelId);
            return View(student);
        }
    }
}
