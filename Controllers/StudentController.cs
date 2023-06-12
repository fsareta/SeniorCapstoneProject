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
      
    }
}
