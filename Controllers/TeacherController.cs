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
        [HttpPost]
        public IActionResult Create(TeacherVM teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            string fileName = SaveUploadedFile(teacher.TeacherPhoto);
            Teacher teach = new Teacher
            {
                Photo = fileName,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Phone = teacher.Phone,
                Email = teacher.Email,
            };
            teach.IsActive = true;
            _context.Teachers.Add(teach);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            //edit Teacer details
            return View();
        }

        private string SaveUploadedFile(IFormFile file)
        {
            if (file != null)
            {
                //What folder to save to
                //use the relative path from the webHostEnvironment
                string folder = Path.Combine(_environment.WebRootPath, "Images");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folder, fileName);
                //we need the path to save the file.
                //we need the file name for the database
                //use a filestream
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    //the using statement closes the filestreams for me
                    //IFormFIle has a method called CopyTo that takes a stream as a parameter
                    file.CopyTo(fs);

                }
                return fileName;
            }
            return "";
        }
    }
}
