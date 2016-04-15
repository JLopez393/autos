using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoAutos.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "Campo Obligatorio.")]
        public String nombre { get; set; }
        [Display(Name = "Usuario"), Required(ErrorMessage = "Campo Obligatorio.")]
        public String user { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.EmailAddress, ErrorMessage = "Formato invalido.")]
        public String correo { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.Password)]
        public String pass { get; set; }

        public int idRol { get; set; }
        public Rol rol { get; set; }

        public virtual List<Pedido> pedido { get; set; }
    }
}