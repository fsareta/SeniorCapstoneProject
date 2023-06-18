namespace SeniorCapstoneProject.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LevelId { get; set; }
        public int CurrentScore { get; set; }
        //navigation
        public Student Student { get; set; }
        public Level Level { get; set; }
    }
}
