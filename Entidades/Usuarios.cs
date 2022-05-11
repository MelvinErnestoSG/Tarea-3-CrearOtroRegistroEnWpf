using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea_3_CrearOtroRegistroEnWpf.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Alias { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int RollId { get; set; }

        [ForeignKey("RollId")]
        public virtual Roles Roles { get; set; }
    }
}
