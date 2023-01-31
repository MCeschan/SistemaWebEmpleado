using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DbEmpleadoContext context;
        public EmpleadoController(DbEmpleadoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //lista de empleados
            var empleados = context.Empleados.ToList();
            //enviar la lista a la vista.
            return View(empleados);
        }
        //---------AGREGAR
        //GET empleado/Create
        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();

            return View("Create", empleado); // esto devuelve al cliente el html.
        }
        //POST empleado/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado); //guardas en memoria
                context.SaveChanges();// guardas en la db.
                return RedirectToAction("Index");
            }
            return View(empleado);
        }
       
        [HttpGet("titulo/{titulo}")]
        public ActionResult<IEnumerable<Empleado>> GetTitulo(string titulo)
        {
            var empleado = (from a in context.Empleados
                            where a.Titulo == titulo
                            select a).ToList();
            return View("GetTitulo", empleado);
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", empleado);
            }
        }

        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {

                return View("Details", empleado);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", empleado);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(empleado);
        }



    }

}

