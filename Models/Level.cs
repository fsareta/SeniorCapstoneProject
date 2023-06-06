namespace SeniorCapstoneProject.Models
{
    public class Level
    {
        private int _score;
        public int Id { get; set; }
        public int StudentAnswer { get; set; }
        public string Question { get; set; }
      
        public int Score { get { return _score; }set { _score = value; } }
        //navigation
        public IEnumerable<Student> Student { get; set; }
    }
}
