using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ExamenMVCachay.Models;
using System.Data.Entity;

namespace ExamenMVCachay.Controllers
{
    public class MovilController : Controller
    {
        Contexto db = new Contexto();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListadoNormal()
        {
            ViewBag.nomMarca = db.Marcas.ToList();
            ViewBag.nomAplicacion = db.Aplicaciones.ToList();
            var moviles = db.Moviles.Include(v => v.Marca).Include(v => v.movil_Aplicaciones).ToList();
            return View(moviles);
        }
        //se accede a traves del Index de Marcas(su lista)
        public ActionResult ListPorEnlace(int marcaID)
        {
            ViewBag.nomAplicacion = db.Aplicaciones.ToList();
            var moviles = db.Moviles.Include(v => v.movil_Aplicaciones).Where(m => m.MarcaID == marcaID).ToList();
            return View(moviles);
        }
        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            ViewBag.AplicacionList = new MultiSelectList(db.Aplicaciones, "ID", "Nombre_Aplicacion");
            ViewBag.MarcaID = new SelectList(db.Marcas, "ID", "Nombre_marca");
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(MovilModelo movil)
        {
            try
            {
                db.Moviles.Add(movil);

                foreach (var aplicacionID in movil.AplicacionesSeleccionadas)
                {
                    var aplicaciones = new Movil_Aplicacion() { aplicacionID = aplicacionID, movilID = movil.ID };
                    db.Movil_Aplicaciones.Add(aplicaciones);
                }

                db.SaveChanges();
                return RedirectToAction("ListadoNormal");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            MovilModelo movil = db.Moviles.Find(id);
            ViewBag.marcaID = new SelectList(db.Marcas, "ID", "Nombre_marca", movil.MarcaID);
            ViewBag.AplicacionesSeleccionadas = db.Movil_Aplicaciones.Where(v => v.movilID == id).Select(v => v.aplicacionID).ToList();
            ViewBag.AplicacionList = new MultiSelectList(db.Aplicaciones, "ID", "Nombre_Aplicacion", movil.AplicacionesSeleccionadas);
            return View(movil);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovilModelo movil)
        {
            try
            {
                MovilModelo oldMovil = db.Moviles.SingleOrDefault(v => v.ID == id);
                oldMovil.Nombre_movil = movil.Nombre_movil;
                oldMovil.Gama = movil.Gama;
                oldMovil.MarcaID = movil.MarcaID;

                var appActuales = db.Movil_Aplicaciones.Where(v => v.movilID == id).Select(v => v);
                foreach (var appEliminar in appActuales)
                {
                    db.Movil_Aplicaciones.Remove(appEliminar);
                }
                foreach (var appAnadir in movil.AplicacionesSeleccionadas)
                {
                    var objetoMovilAplicacion = new Movil_Aplicacion() { aplicacionID = appAnadir, movilID = movil.ID };
                    db.Movil_Aplicaciones.Add(objetoMovilAplicacion);
                }
                db.SaveChanges();
                return RedirectToAction("ListadoNormal");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.nomMarca = db.Marcas.ToList();
            MovilModelo movil = db.Moviles.Include(v => v.Marca).Include(v => v.movil_Aplicaciones).Single(v => v.ID == id);
            return View(movil);
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MovilModelo movil)
        {
            try
            {
                movil = db.Moviles.Find(id);
                var apps = db.Movil_Aplicaciones.Where(uv => uv.movilID == id).Select(uv => uv);
                foreach (var appEliminar in apps)
                {
                    db.Movil_Aplicaciones.Remove(appEliminar);
                }

                db.Moviles.Remove(movil);
                db.SaveChanges();

                return RedirectToAction("ListadoNormal");
            }
            catch
            {
                return View();
            }
        }
    }
}
