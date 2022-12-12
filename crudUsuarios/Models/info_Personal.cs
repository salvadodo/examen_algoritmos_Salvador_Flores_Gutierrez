namespace crudUsuarios.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class info_Personal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Dirección { get; set; }

        public int Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
    }
}
