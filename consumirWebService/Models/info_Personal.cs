using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace consumirWebService.Models
{
    public class info_Personal
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Dirección { get; set; }

        public int Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
    }
}