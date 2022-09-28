using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluLogistics.DataModel.Model
{
    public partial class Libros
    {
        public Guid LibrosID { get; set; }

        public Guid EditorialesID { get; set; }

        [Required]
        [StringLength(45)]
        public string Tittulo { get; set; }

        [Column(TypeName = "text")]
        public string Sinopsis { get; set; }

        [StringLength(45)]
        public string NPaginas { get; set; }
    }
}
