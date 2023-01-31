using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;

namespace SistemaWebEmpleado.Data
{
    public class DbEmpleadoContext:DbContext
    {
        public DbEmpleadoContext(DbContextOptions<DbEmpleadoContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
