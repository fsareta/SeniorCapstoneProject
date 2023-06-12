using SeniorCapstoneProject.Services;

namespace SeniorCapstoneProject.Models
    
{
   
    public class QnA
    {
        public int Id { get; set; }
        public string MathEquation { get; set; }
        public string Answer { get; set; }
        public int LevelId { get; set; }
    }
}
