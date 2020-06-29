using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialPontVerges.Models
{
    public class Socio
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public int idTipoDoc { get; set; }
        [Required]
        public int nroDoc { get; set; }
        [Required]
        public int idDeporte { get; set; }
    }
}