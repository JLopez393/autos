using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoAutos.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "Campo oblitorio.")]
        public String nombre { get; set; }
        [Display(Name = "Descripcion"), Required(ErrorMessage = "Campo obligatorio")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuario { get; set; }
    }
}