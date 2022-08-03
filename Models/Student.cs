using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcFiliere.Models;

namespace MvcStudent.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Key]
        [ForeignKey("FiliereID")]
        public int FiliereID { get; set; }
        public virtual Filiere Filiere_id { get; set; } = default!;
    }
}