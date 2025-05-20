using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    public class Cliente : Usuario
    {
        public string TipoMembresia { get; set; }

        public Cliente()
        {
            Rol = "Cliente";
        }

        public override void MostrarPermisos()
        {
            // Lógica específica para clientes
            Console.WriteLine("Permisos: Ver e inscribirse en clases disponibles según su membresía.");
        }
    }
}
