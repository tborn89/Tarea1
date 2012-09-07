using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Tarea1.Models
{
    public class RegistroGuardia
    {
        public int RegistroGuardiaId { get; set; }
        [Required(ErrorMessage = "El voluntario es obligatorio")]
        [Display(Name = "Voluntario")]
        public int IntegranteId { get; set; }
        public Integrante Integrante { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        [DataType(DataType.Date, ErrorMessage="Ingrese una fecha válida")]
        [Display(Name="Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        
        [DataType(DataType.Date, ErrorMessage="Ingrese una fecha válida")]
        [CustomValidation(typeof(RegistroGuardia),"RevisarFechaSalidaVieneDespuesDeFechaIngreso")]
        [Display(Name = "Fecha de Salida")]
        public DateTime? FechaSalida { get; set; }

        public static ValidationResult RevisarFechaSalidaVieneDespuesDeFechaIngreso(DateTime? fechaSalida, ValidationContext pValidationContext)
        {
            RegistroGuardia registroGuardia = (RegistroGuardia)pValidationContext.ObjectInstance;
            if (registroGuardia.FechaIngreso != null && fechaSalida != null && registroGuardia.FechaIngreso > fechaSalida)
                return new ValidationResult("La fecha de salida debe ser posterior a la de ingreso!", new List<string> { "FechaSalida" });
            return ValidationResult.Success;
        }

    }
}