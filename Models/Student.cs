﻿using System.ComponentModel.DataAnnotations;

namespace SeniorCapstoneProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Photo { get; set; }
        [Required]
        public bool Enrolled { get; set; }
        [Required]
        public int TeacherId { get; set; }
     
        //navigation
        public Teacher Teacher { get; set; }
        public Score Score { get; set; }
      

    }
}
