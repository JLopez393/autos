using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoAutos.Models
{
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }
       
        public int idAutos { get; set; }
        public virtual Autos auto { get; set; }
        public int idUsuario { get; set; }
        public virtual Usuario usuario { get; set; }

    }
}