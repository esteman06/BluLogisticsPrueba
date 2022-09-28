using System;

namespace BluLogistics.DataModel.Model
{
    public partial class Autores_has_libros
    {
        public Guid Autores_has_librosID { get; set; }
        public Guid AutoresID { get; set; }
        public Guid LibrosID { get; set; }
    }
}
