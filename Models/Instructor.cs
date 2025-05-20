using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    internal class Instructor : Usuario
    {
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }

        public Instructor()
        {
            Rol = "Instructor";
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine("Permisos: Ver y gestionar las clases a su cargo.");
        }
    }
}
