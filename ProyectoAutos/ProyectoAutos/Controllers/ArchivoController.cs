using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;

namespace ProyectoAutos.Controllers
{
    public class ArchivoController : Controller
    {

        private DB_AUTOS db = new DB_AUTOS();
        //
        // GET: /Archivo/
        public ActionResult Obtener(int id)
        {
            var imagen = db.archivo.Find(id);

            return File(imagen.contenido,imagen.ContentType);
        }
	}
}