using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcFiliere.Models;

namespace MvcCour.Models
{
    public class Cour
    {
        [Key]
        public int CourId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;    

        [ForeignKey("FiliereID")]
        public int FiliereID { get; set; }
        public virtual Filiere Filiere_id { get; set; } = default!;
    }
}
