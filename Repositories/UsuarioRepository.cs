using System;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Factories;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class UsuarioRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-0KBBNKK;Initial Catalog=Herramientas;Integrated Security=True";

        public Usuario ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;

            string query = "SELECT UsuarioID, NombreUsuario, Rol, Nombre, Apellido, Telefono FROM Usuarios WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string rol = reader["Rol"].ToString();

                        usuario = UsuarioFactory.CrearUsuario(rol);
                        usuario.UsuarioID = (int)reader["UsuarioID"];
                        usuario.Nombre = reader["Nombre"].ToString();
                        //usuario.Apellido = reader["Apellido"].ToString();
                        //usuario.Telefono = reader["Telefono"].ToString();
                    }
                }
            }

            return usuario;
        }
    }
}
