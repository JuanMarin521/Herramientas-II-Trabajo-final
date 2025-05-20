using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Factories
{
    public static class UsuarioFactory
    {
        public static Usuario CrearUsuario(string rol)
        {
            if (rol == "Administrador")
            {
                return new Administrador();
            }
            else if (rol == "Instructor")
            {
                return new Instructor();
            }
            else if (rol == "Cliente")
            {
                return new Cliente();
            }
            else
            {
                throw new ArgumentException("Rol no válido");
            }
        }
    }
}
