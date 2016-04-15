using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;
namespace ProyectoAutos.Controllers
{
    public class PerfilController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();
        //
        // GET: /Perfil/
        public ActionResult Index()
        {
            int idUsuario = (int)Session["idUsuario"];
            Usuario usuario = db.usuario.Find(idUsuario);
            return View(usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol = new SelectList(db.rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombre,user,correo,pass,idRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRol = new SelectList(db.rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }
	}
}