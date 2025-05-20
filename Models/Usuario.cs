using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    public abstract class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; } 
        public string Rol { get; protected set; }

        // Método que se puede sobrescribir para mostrar permisos u otra lógica específica
        public abstract void MostrarPermisos();
    }
}
