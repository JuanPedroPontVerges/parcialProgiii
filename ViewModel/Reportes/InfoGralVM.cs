using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.AccesoDatos;

namespace ParcialPontVerges.ViewModel.Reportes
{
    public class InfoGralVM
    {
        public List<DeporteVM> listaDeportes { get; set; }
        public List<SocioItemVM> listaSocio { get; set; }

        public void CargarVariables()
        {
            
            listaDeportes = AD_Reportes.ObtenerCantidadPorDeporte();
            listaSocio = AD_Reportes.ObtenerReportePersona();
        }

        public InfoGralVM()
        {
            listaDeportes = new List<DeporteVM>();
            listaSocio = new List<SocioItemVM>();
            CargarVariables();
        }

    }
}