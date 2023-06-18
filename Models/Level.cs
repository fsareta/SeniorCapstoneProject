namespace SeniorCapstoneProject.Models
{
    public class Level
    {
        
        public int Id { get; set; }
        public bool IsUnlocked { get; set; }
        //navigation
        public Score Score { get; set; }
        public IEnumerable<QnA> QnA { get; set; }
    }
}
