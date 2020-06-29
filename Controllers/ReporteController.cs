using ParcialPontVerges.ViewModel.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialPontVerges.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Reporte()
        {
            InfoGralVM resultado = new InfoGralVM();
            return View(resultado);
        }
    }
}