using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    public class Cliente : Usuario
    {
        public string TipoMembresia { get; set; } // Básico, VIP, Premium

        public Cliente()
        {
            Rol = "Cliente";
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine("Acceso limitado a clases según membresía.");
        }
    }
}
