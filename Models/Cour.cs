using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcFiliere.Models;

namespace MvcCour.Models
{
    public class Cour
    {
        public int CourId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;    

        [Key]
        [ForeignKey("FiliereID")]
        public int FiliereID { get; set; }
        public virtual Filiere Filiere_id { get; set; } = default!;
    }
}
