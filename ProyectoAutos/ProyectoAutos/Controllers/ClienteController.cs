using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;
namespace ProyectoAutos.Controllers
{
    public class ClienteController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            return View(db.auto.ToList());
        }
        public ActionResult Pedido()
        {
            return RedirectToAction("Pedido", "Pedido");
        }
	}
}