using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BluLogistics.DataModel.Model
{
    public partial class Autores
    {
        public Guid AutoresID { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string Apellidos { get; set; }
    }
}
