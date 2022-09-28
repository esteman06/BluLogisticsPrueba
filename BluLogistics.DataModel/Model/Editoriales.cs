using System;
using System.ComponentModel.DataAnnotations;

namespace BluLogistics.DataModel.Model
{
    public partial class Editoriales
    {
        public Guid EditorialesID { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [StringLength(45)]
        public string Sede { get; set; }
    }
}
