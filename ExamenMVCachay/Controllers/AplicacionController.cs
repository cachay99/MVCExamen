using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ExamenMVCachay.Models;

namespace ExamenMVCachay.Controllers
{
    public class AplicacionController : Controller
    {
        // GET: Default1
        Contexto db = new Contexto();
        public ActionResult Index()
        {
            var apps = db.Aplicaciones.ToList();
            return View(apps);
        }

        // GET: Default1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default1/Create
        [HttpPost]
        public ActionResult Create(AplicacionModelo aplicacion)
        {
            try
            {
                db.Aplicaciones.Add(aplicacion);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Edit/5
        public ActionResult Edit(int id)
        {
            AplicacionModelo app = db.Aplicaciones.Find(id);
            return View(app);
        }

        // POST: Default1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AplicacionModelo aplicacion)
        {
            try
            {
                AplicacionModelo oldApp = db.Aplicaciones.Find(id);
                oldApp.Nombre_Aplicacion = aplicacion.Nombre_Aplicacion;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default1/Delete/5
        public ActionResult Delete(int id)
        {
            AplicacionModelo app = db.Aplicaciones.Find(id);
            return View(app);
        }

        // POST: Default1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AplicacionModelo aplicacion)
        {
            try
            {
                aplicacion = db.Aplicaciones.Find(id);

                var apps = db.Movil_Aplicaciones.Where(uv => uv.aplicacionID == id).Select(uv => uv);
                foreach (var appEliminar in apps)
                {
                    db.Movil_Aplicaciones.Remove(appEliminar);
                }
                db.Aplicaciones.Remove(aplicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
