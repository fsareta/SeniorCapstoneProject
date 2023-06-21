using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.ViewModels
{
    public class GameVM
    {
        public IEnumerable<QnA> Questions { get; set; }
        public Level Level { get; set; }
        public IEnumerable< StudentAnswer> StudentAnswers { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QnAId { get; set; }
        public string StuAnswer { get; set; }
        //navigatin
        public QnA Question { get; set; }

    }
}
