namespace SeniorCapstoneProject.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QnAId { get; set; }
        public string StuAnswer { get; set; }
        //navigatin
        public Student Student { get; set; }
        public QnA Question { get; set; }

        
    }
}
