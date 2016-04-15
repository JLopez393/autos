using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ProyectoAutos.Models
{
    public class DB_AUTOS:DbContext
    {
        public DB_AUTOS() : base("Name= db_autos") { }
        public virtual DbSet<Rol> rol { get; set;}
        public virtual DbSet<Usuario> usuario { get; set;}
        public virtual DbSet<Autos> auto { get; set; }
        public virtual DbSet<Pedido> pedido { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; } 
    }
}