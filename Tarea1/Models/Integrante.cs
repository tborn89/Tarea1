using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tarea1.Models
{
    public class Integrante
    {
        public int IntegranteId {get; set;}
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "El cargo es obligatorio")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public virtual List<RegistroGuardia> RegistroGuardias { get; set; }

        public string NombreCompleto
        {
            get { return this.Nombre + " " + this.Apellido; }
        }

        public static Integrante ObtenerCargoMasAlto(List<Integrante> voluntarios)
        {
            if (voluntarios != null && voluntarios.Count > 0)
            {
                int prioridadGanadora = Int32.MaxValue;
                Integrante ganador = null;
                foreach (Integrante integrante in voluntarios)
                {
                    if (integrante.Cargo.Prioridad < prioridadGanadora)
                    {
                        ganador = integrante;
                        prioridadGanadora = ganador.Cargo.Prioridad;
                    }
                }
                return ganador;
            }
            else
                return null;
        }

    }
}