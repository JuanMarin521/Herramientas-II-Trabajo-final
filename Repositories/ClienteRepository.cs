using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Data; // Aquí está el DatabaseSingleton

namespace Trabajo_final_herramientas_II.Repositories
{
    public class ClienteRepository
    {
        private readonly SqlConnection connection;

        public ClienteRepository()
        {
            connection = DatabaseSingleton.Instance.Connection;
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "SELECT * FROM Clientes";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            ClienteID = Convert.ToInt32(reader["ClienteID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            TipoMembresia = reader["TipoMembresia"].ToString()
                        });
                    }
                }
            }

            return clientes;
        }

        public bool Insertar(Cliente cliente)
        {
            string query = @"INSERT INTO Clientes (Nombre, Apellido, Telefono, TipoMembresia)
                             VALUES (@Nombre, @Apellido, @Telefono, @TipoMembresia)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            string query = @"UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido,
                             Telefono = @Telefono, TipoMembresia = @TipoMembresia
                             WHERE ClienteID = @ClienteID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                // Asegúrate de que tienes la directiva using correcta para la clase Cliente
                // Agrega esto al inicio del archivo si no está presente:
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int clienteID)
        {
            string query = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", clienteID);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}