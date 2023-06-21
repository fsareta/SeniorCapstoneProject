using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorCapstoneProject.Data;
using SeniorCapstoneProject.Models;
using SeniorCapstoneProject.ViewModels;

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
            IEnumerable<Student> students = _context.Students.Include(x => x.Score);
            return View(students);
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            IEnumerable<Score> scores = _context.Scores.Where(x => x.StudentId == student.Id);
            AllLevelsVM model = new AllLevelsVM 
            {
                Student = student,
                Scores = scores
            };
            return View(model);
        }
        public IActionResult StudAnswerById(int id)
        {//not working
            if (id == 0)
            {
                return NotFound();
            }
            Student student=_context.Students.SingleOrDefault(x=>x.Id== id);
   
            IEnumerable<StudentAnswer> answers=_context.StudentAnswers.Where(x => x.StudentId==student.Id);
            GameVM model = new GameVM
            {
                Student = student,
                StudentAnswers = answers,
                
            };
            
            return View(model);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> teacherList = _context.Teachers.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            });
            StudentVM model = new StudentVM
            {
                TeacherList = teacherList,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            string fileName = SaveUploadedFile(student.StudentPhoto);
            
            Student st = new Student
            {
                Photo = fileName,
                FirstName = student.FirstName,
                LastName = student.LastName,
                TeacherId = student.TeacherId,
               
            };
            student.Enrolled = true;
            _context.Students.Add(st);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Teacher teacher = _context.Teachers.SingleOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            student.Teacher = teacher;
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                student.Teacher = _context.Teachers.SingleOrDefault(x => x.Id == student.TeacherId);
                return View(student);
            }
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            Student s = _context.Students.SingleOrDefault(x => x.Id == student.Id);
            if (s == null)
            {
                return NotFound();
            }
            s.Enrolled = false;
            _context.Students.Update(s);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

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
