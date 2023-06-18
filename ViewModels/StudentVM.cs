using Microsoft.AspNetCore.Mvc.Rendering;
using SeniorCapstoneProject.Models;
using SeniorCapstoneProject.Validation;
using System.ComponentModel.DataAnnotations;

namespace SeniorCapstoneProject.ViewModels
{
    public class StudentVM
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
        //store a photo
        [StringLength(100)]
        public string Photo { get; set; }
        [Required]
        public bool Enrolled { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public IEnumerable<SelectListItem> TeacherList { get; set; }
  
        //navigation
        public Teacher Teacher { get; set; }
        public Score Score { get; set; }
       
      
        //uploaded image
        [Display(Name = "Upload Photo")]
        [PhotoValidation]
        public IFormFile StudentPhoto { get; set; }
    }
}
