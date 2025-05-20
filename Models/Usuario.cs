using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    public abstract class Usuario
    {
        public int UsuarioID { get; set; } // Puede ser ClienteID, InstructorID, etc.
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; protected set; }

        // Método que se puede sobrescribir para mostrar permisos u otra lógica específica
        public abstract void MostrarPermisos();
    }
}
