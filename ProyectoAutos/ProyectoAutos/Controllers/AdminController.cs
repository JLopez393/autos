using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAutos.Models;
using System.Data.Entity.Infrastructure;

namespace ProyectoAutos.Controllers
{
    public class AdminController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.auto.ToList());
        }
        public ActionResult Listar()
        {
            return View(db.auto.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autos autos = db.auto.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutos,nombre,marca,modelo,precio")] Autos autos, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.ContentLength > 0)
                {
                    var imagen = new Archivo
                    {
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FyleType.Imagen,
                        ContentType = archivo.ContentType
                    };
                    using (var read = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = read.ReadBytes(archivo.ContentLength);
                    };
                    autos.archivo = new List<Archivo> { imagen };
                }
                db.auto.Add(autos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autos);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autos autos = db.auto.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        // POST: /Admin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase archivo)
        {
          if(id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          var auto = db.auto.Find(id);
            if(TryUpdateModel(auto, "", new String[] {"idAutos,nombre,marca,modelo,precio"})){
                try{
                    if (archivo != null && archivo.ContentLength > 0){
                        if(auto.archivo.Any(a => a.tipo == FyleType.Imagen)){
                            db.archivo.Remove(auto.archivo.First(a => a.tipo == FyleType.Imagen));
                    }
                        var imagen = new Archivo
                        {
                             nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipo = FyleType.Imagen,
                            ContentType = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream)){
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        }
                            auto.archivo = new List<Archivo>{imagen};
                        }
                        db.Entry(auto).State = EntityState.Modified;
                        db.SaveChanges();

                        return RedirectToAction("Index");
                        }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("","Unable to save Chandes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(auto);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autos autos = db.auto.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autos autos = db.auto.Find(id);
            db.auto.Remove(autos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
