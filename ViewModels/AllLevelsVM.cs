using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.ViewModels
{
    public class AllLevelsVM
    {
        public IEnumerable<Score> Scores { get; set; }
        public Student Student { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
