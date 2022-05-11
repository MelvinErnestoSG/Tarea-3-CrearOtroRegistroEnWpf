using System;
using System.ComponentModel.DataAnnotations;

namespace Tarea_3_CrearOtroRegistroEnWpf.Entidades
{
    public class Roles
    {
        [Key]
        public int RollId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
    }
}
