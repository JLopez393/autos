using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;
using System.Net;
using System.Data.Entity;
namespace ProyectoAutos.Controllers
{
    public class PedidoController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();
        //
        // GET: /Pedido/
        public ActionResult Pedido(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autos auto = db.auto.Find(id);
            Usuario usuario = db.usuario.Find((int)Session["idUsuario"]);
            Pedido pedido = new Pedido();
            pedido.idUsuario = (int)Session["idUsuario"];
            pedido.idAutos = (int)id;
            //pedido.total = Double.Parse(auto.precio);
            pedido.auto = auto;
            pedido.usuario = usuario;

            return View(pedido);
        }
        public ActionResult Comprar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Autos auto = db.auto.Find(id);
            Usuario usuario = db.usuario.Find((int)Session["idUsuario"]);
            Pedido pedido = new Pedido();
            pedido.idUsuario = (int)Session["idUsuario"];
            pedido.idAutos = (int)id;
            //pedido.total = Double.Parse(auto.precio);
            pedido.auto = auto;
            pedido.usuario = usuario;

            return View(pedido);
        }
        public ActionResult MisPedidos(int? id) {
            Autos auto = db.auto.Find(id);
            Usuario usuario = db.usuario.Find(Session["idUsuario"]);
            Pedido pedido = new Pedido();

            pedido.auto = auto;
            pedido.usuario = usuario;
            pedido.idUsuario = usuario.idUsuario;
            pedido.idAutos = (int)id;

            db.Entry(auto).State = EntityState.Modified;

            db.pedido.Add(pedido);
            db.SaveChanges();
            return View(pedido);
        }

        public ActionResult MisCompras()
        {
            return View();
        }
	}
}