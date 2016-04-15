using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoAutos.Models
{
    public class Autos
    {
        [Key]
        public int idAutos { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "Campo Obligatorio")]
        public String nombre { get; set; }
        [Display(Name = "Marca"), Required(ErrorMessage = "Campo Obligatorio")]
        public String marca { get; set; }
        [Display(Name = "Modelo"), Required(ErrorMessage = "Campo Obligatorio")]
        public String modelo { get; set; }
        [Display(Name = "Precio"), Required(ErrorMessage = "Campo Obligatorio")]
        public Double precio { get; set; }
        public int estado { get; set; }

        public virtual List<Archivo> archivo { get; set; }
        public virtual List<Pedido> pedido { get; set; }
    }
}