using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.ViewModels
{
    public class ClassListVM
    {
        public IEnumerable<Student> Students { get; set; }
        public Teacher Teacher { get; set; }

        public Level Level { get; set; }
    }
}
