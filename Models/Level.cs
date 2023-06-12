namespace SeniorCapstoneProject.Models
{
    public class Level
    {
        
        public int Id { get; set; }
        public bool IsLocked { get; set; }
        //navigation
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<QnA> QnA { get; set; }
    }
}
