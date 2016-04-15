using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoAutos.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set;}
        public String nombre { get; set; }
        public String ContentType { get; set; }
        public FyleType tipo { get; set; }
        public Byte[] contenido { get; set; }
        public int idAutos { get; set; }
        public virtual Autos auto { get; set; }
    }
}