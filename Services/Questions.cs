namespace SeniorCapstoneProject.Services
{
    public class Questions : IQuestions
    {
        Random random;
        
        public Questions()
        {
            random=new Random();
        }
      
        public int RandomNumber()
        {
           return random.Next(0,10);
        }
      


    }
}
