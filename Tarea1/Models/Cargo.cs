using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }
        [Required(ErrorMessage="El titulo es obligatorio")] 
        public string Titulo { get; set; }
        [Required(ErrorMessage="La prioridad es obligatoria")]
        [Range(0, Int32.MaxValue)]
        public int Prioridad { get; set; }
        public List<Integrante> Integrantes { get; set; }
    }
}