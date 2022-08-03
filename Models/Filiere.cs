using System.ComponentModel.DataAnnotations;

namespace MvcFiliere.Models
{
    public class Filiere
    {
        [Key]
        public int FiliereId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;    
    }
}
