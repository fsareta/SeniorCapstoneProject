using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorCapstoneProject.Data;
using SeniorCapstoneProject.Models;
using SeniorCapstoneProject.ViewModels;

namespace SeniorCapstoneProject.Controllers
{
    public class TeacherController : Controller
    {
        //inject DbContext
        ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public TeacherController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            IEnumerable<Teacher> teachers = _context.Teachers.Include(x => x.Students);
            return View(teachers);
        }
        public IActionResult ClassList(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Teacher teacher = _context.Teachers.SingleOrDefault(x => x.Id == id);
            Level level = _context.Levels.SingleOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            IEnumerable<Student> students = _context.Students.Where(x => x.TeacherId == teacher.Id);
            ClassListVM classList = new ClassListVM
            {
                Students = students,
                Teacher = teacher,
                Level = level,
            };
            return View(classList);
        }
        public IActionResult Create()
        {
            //create new Teacher
            return View();
        }
        public IActionResult Edit()
        {
            //edit Teacer details
            return View();
        }
    }
}
