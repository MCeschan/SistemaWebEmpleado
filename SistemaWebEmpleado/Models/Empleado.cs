using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        public int DNI { get; set; }

        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [RegularExpression(@"^[A]{2}[1-9]{5}$", ErrorMessage = "Se aceptan 2 A al comienzo y cuatro números")]
        public string Legajo { get; set; }
        [MayorDosmil]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este es un campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }
    }
}
