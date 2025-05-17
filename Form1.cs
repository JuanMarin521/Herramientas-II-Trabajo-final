using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Trabajo_final_herramientas_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0KBBNKK;Initial Catalog=Herramientas;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0KBBNKK;Initial Catalog=Herramientas;Integrated Security=True");
                connection.Open();
                MessageBox.Show("Conexión exitosa a la base de datos.");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-0KBBNKK;Initial Catalog=Herramientas;Integrated Security=True";

            string query = "INSERT INTO Clientes (Nombre, Apellido, Telefono, TipoMembresia) VALUES (@Nombre, @Apellido, @Telefono, @TipoMembresia)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@TipoMembresia", cmbMembresia.SelectedItem.ToString());

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Cliente registrado exitosamente.");
                    else
                        MessageBox.Show("No se insertó ningún dato.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
