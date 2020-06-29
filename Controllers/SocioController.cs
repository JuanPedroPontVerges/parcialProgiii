using ParcialPontVerges.AccesoDatos;
using ParcialPontVerges.Models;
using ParcialPontVerges.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialPontVerges.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult AltaSocio()
        {
            List<DeporteVM> listaDeportes = Ad.obtenerListaDeportes();
            List<SelectListItem> itemsDeportes = listaDeportes.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idDeporte.ToString(),
                    Selected = false
                };
            });

            List<TipoDocVM> listaDocs = Ad.obtenerListaDoc();
            List<SelectListItem> itemsDocs = listaDocs.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idTipoDoc.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsDocs = itemsDocs;
            ViewBag.itemsDeportes = itemsDeportes;

            return View();
        }

        [HttpPost]
        public ActionResult AltaSocio(Socio s)
        {
            bool resultado = Ad.InsertarNuevaPersona(s);
            if(resultado)
                return RedirectToAction("ListadoSocios","Socio");
            else
            {
                return View();
            }
        }

        public ActionResult ListadoSocios()
        {
            List<Socio> lista = Ad.ObtenerListaSocios();
            return View(lista);
        }
    }
}
