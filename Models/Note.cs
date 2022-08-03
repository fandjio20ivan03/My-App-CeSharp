using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcFiliere.Models;
using MvcCour.Models;

namespace MvcNote.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        [ForeignKey("FiliereID")]
        public int FiliereID { get; set; }
        public virtual Filiere Filiere_id { get; set; } = default!;

        [ForeignKey("CourID")]
        public int CourID { get; set; }
        public virtual Cour Cour_id { get; set; } = default!;

        public double Value { get; set; }
    }
}
