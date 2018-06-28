using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required]
        public Salutation Salutation { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Full Name")]
        [NotMapped]
        public string FullName { get { return $"{Salutation} {FirstName} {Surname}"; } }
        [Display(Name = "Age")]
        [Required]
        [Range(0, 200, ErrorMessage = "Please enter a valid Age")]
        public int Age { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public Gender Gender { get; set; }
    }
}