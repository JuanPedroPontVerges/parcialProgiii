using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcialPontVerges.ViewModel
{
    public class SocioItemVM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string nombreTipoDoc { get; set; }

        public int nroDoc { get; set; }

        public string nombreDeporte { get; set; }
    }
}