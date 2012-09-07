using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tarea1.Models
{
    public class Tarea1DbContext : DbContext
    {
        public Tarea1DbContext()
            : base("Tarea1")
        {

        }

        public DbSet<Integrante> Integrantes { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<RegistroGuardia> RegistroGuardias { get; set; }
        public List<Integrante> ObtenerVoluntariosEnGuardia()
        {
            List<Integrante> voluntariosEnGuardia = RegistroGuardias.Where(x => (x.FechaIngreso < DateTime.Now) && (x.FechaSalida == null || x.FechaSalida > DateTime.Now)).Select(x => x.Integrante).Include(x=>x.Cargo).ToList();
            return voluntariosEnGuardia;
        }

        public int DiasDeGuardiaDeVoluntario(int voluntarioId)
        {
            var guardias = RegistroGuardias.Where(x => x.IntegranteId == voluntarioId).Select(a => new { FechaIngreso = a.FechaIngreso, FechaSalida = a.FechaSalida }).ToList();
            int diasTotales = 0;
            foreach (var guardia in guardias)
            {
                if (guardia.FechaSalida == null)
                {
                    diasTotales += (DateTime.Now - guardia.FechaIngreso).Days;
                }
                else
                {
                    diasTotales += ((DateTime)guardia.FechaSalida - guardia.FechaIngreso).Days;
                }
            }
            return diasTotales;
        }
    }
}