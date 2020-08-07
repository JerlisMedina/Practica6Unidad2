using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica6Unidad2.Models;

namespace Practica6Unidad2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroProducto rp = new RegistroProducto();
            return View(rp.MostrarTodos());
        }

        public ActionResult Guardar() {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(FormCollection collection) {
            RegistroProducto rp = new RegistroProducto();

            Producto prod = new Producto() {
                Id = int.Parse(collection["Codigo"]),
                Descripcion = collection["Descripcion"],
                Tipo = collection["Tipo"],
                Precio = double.Parse(collection["Precio"])
            };

            rp.GrabarProducto(prod);

            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int cod) {
            RegistroProducto rp = new RegistroProducto();
            rp.Borrar(cod);
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int cod) {
            RegistroProducto rp = new RegistroProducto();
            rp.MostrarEspecifico(cod);
            return View(rp);
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection collection) {
            RegistroProducto rp = new RegistroProducto();

            Producto prod = new Producto
            {
                Id = int.Parse(collection["Codigo"]),
                Descripcion = collection["Descripcion"],
                Tipo = collection["Tipo"],
                Precio = double.Parse(collection["Precio"])
            };

            rp.Modificar(prod);
            return RedirectToAction("Index");
        }
    }
}