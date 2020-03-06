﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ExamenMVCachay.Models;

namespace ExamenMVCachay.Controllers
{
    public class MarcaController : Controller
    {
        Contexto db = new Contexto();
        // GET: Default2
        //Listado
        public ActionResult Index()
        {
            var marcas = db.Marcas.ToList();
            return View(marcas);
        }

        // GET: Default2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default2/Create
        [HttpPost]
        public ActionResult Create(MarcaModelo marca)
        {
            try
            {
                db.Marcas.Add(marca);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default2/Edit/5
        public ActionResult Edit(int id)
        {
            MarcaModelo marca = db.Marcas.Find(id);
            return View(marca);
        }

        // POST: Default2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MarcaModelo marca)
        {
            try
            {
                MarcaModelo oldMarca = db.Marcas.Find(id);
                oldMarca.Nombre_marca = marca.Nombre_marca;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default2/Delete/5
        public ActionResult Delete(int id)
        {
            MarcaModelo marca = db.Marcas.Find(id);
            return View(marca);
        }

        // POST: Default2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MarcaModelo marca)
        {
            try
            {
                marca = db.Marcas.Find(id);

                var moviles = db.Moviles.Where(m => m.MarcaID == id).Select(m=>m);
                var movilesApp = db.Movil_Aplicaciones.Where(v => v.Movil == moviles).Select(v => v);
                foreach (var movilEliminar in moviles)
                {
                    db.Moviles.Remove(movilEliminar);
                }
                foreach (var movilAppEliminar in movilesApp)
                {
                    db.Movil_Aplicaciones.Remove(movilAppEliminar);
                }

                db.Marcas.Remove(marca);
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
