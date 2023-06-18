using SeniorCapstoneProject.Models;
using SeniorCapstoneProject.Validation;
using System.ComponentModel.DataAnnotations;

namespace SeniorCapstoneProject.ViewModels
{
    public class TeacherVM
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
        [StringLength(100)]
        public string Photo { get; set; }
        [Required]
        public bool IsActive { get; set; }

        //uploaded image
        [Display(Name = "Upload Photo")]
        [PhotoValidation]
        public IFormFile TeacherPhoto { get; set; }
        //navigation
        public IEnumerable<Student> Students { get; set; }
    }
}
