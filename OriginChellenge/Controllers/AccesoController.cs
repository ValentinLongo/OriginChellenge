﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OriginChellenge.Models;

namespace OriginChellenge.Controllers
{
    public class AccesoController : Controller
    {
        public static int IdTarjetaLogin;
        public static int Errores = 0;
        public static int IdTarjetaErronea;
        // GET: Acceso
        public ActionResult Tarjeta()
        {
            return View();
        }

        public ActionResult PIN()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarTarjeta(Tarjeta mTarjeta)
        {
            Tarjeta tarj = new Tarjeta();
            using (dbOriginEntities2 db = new dbOriginEntities2())
            {
                tarj = db.Tarjeta.Where(t => t.NumeroTarjeta == mTarjeta.NumeroTarjeta).FirstOrDefault();
                
            }
            if (tarj == null)
            {
                return RedirectToAction("Error", "Error");
            }
            else if(tarj.Bloqueada == 1)
            {
                return RedirectToAction("Error", "Error");
            }
            else
            {
                IdTarjetaErronea = Convert.ToInt32(tarj.IdTarjeta);
                return RedirectToAction("PIN", "Acceso");
            }
        }

        private void bloquear()
        {
            Tarjeta tarj = new Tarjeta();
            using (dbOriginEntities2 db = new dbOriginEntities2())
            {
                tarj = db.Tarjeta.Where(t => t.IdTarjeta == IdTarjetaErronea).FirstOrDefault();
                tarj.Bloqueada = 1;
                db.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult VerificarPIN(Tarjeta mTarjeta)
        {
            Tarjeta tarj = new Tarjeta();
            using (dbOriginEntities2 db = new dbOriginEntities2())
            {
                tarj = db.Tarjeta.Where(t => t.PIN == mTarjeta.PIN).FirstOrDefault(); 
            }
            if(Errores <= 4)
            {
                if (tarj == null)
                {
                    Errores++;
                    return RedirectToAction("Error", "Error");
                }
                else
                {
                    IdTarjetaLogin = Convert.ToInt32(tarj.IdTarjeta);
                    Errores = 0;
                    return RedirectToAction("Inicio", "Inicio");
                }
            }
            else
            {
                bloquear();
                return RedirectToAction("Error", "Error");
            }

        }

        [HttpPost]
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Tarjeta", "Acceso");
        }
    }
}