using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
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
        ////empleados por título
        //[HttpGet]
        //public ActionResult Titulo(string titulo)
        //{
        //    var titulo = context.Empleados.Find(titulo);
        //    if (aula == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return View("Details", aula);
        //    }
        //}

    }
}
