using System.ComponentModel.DataAnnotations;

namespace SeniorCapstoneProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Photo { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //navigation
        public IEnumerable<Student> Students { get; set; }
    }
}
