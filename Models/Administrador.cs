using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    internal class Administrador : Usuario
    {
        public Administrador()
        {
            Rol = "Administrador";
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine("Permisos: Acceso completo al sistema.");
        }
    }
}
