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
    }
}
