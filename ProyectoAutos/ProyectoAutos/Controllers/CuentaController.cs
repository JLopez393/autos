using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;

namespace ProyectoAutos.Controllers
{
    public class CuentaController : Controller
    {
        public DB_AUTOS db = new DB_AUTOS();
        //
        // GET: /Cuenta/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.user == usuario.user && u.pass == usuario.pass);
            if (usr != null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Verifique sus credenciales.");
            }
            return View();
        }

        public ActionResult Registro()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario usr)
        {

            var existe = db.usuario.FirstOrDefault(u => u.user == usr.user);
            if (existe == null)
            {
                var rool = db.rol.FirstOrDefault(r => r.idRol == 2);
                usr.rol = rool;
                db.usuario.Add(usr);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usr.nombre + " ha sido registrado exitosamente";
            }
            else { ViewBag.mensaje = "Usuario " + usr.user + " ya esta registrado."; }
            return View();
        }

        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"] != null)
            {
                if (Session["nombreUsuario"].Equals("ADMINISTRADOR"))
                {
                    return RedirectToAction("../Admin/Index");
                }else{
                    return RedirectToAction("../Cliente/Index");
                }
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("nombreUsuario");
            Session.Remove("idUsuario");
            return RedirectToAction("Login");
        }
    }
}