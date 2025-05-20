using System;
using System.Windows.Forms;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormInstructor : Form
    {
        private Usuario usuario;

        public FormInstructor(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            // Aquí puedes usar los datos del usuario
            MessageBox.Show($"Bienvenido, {usuario.Nombre} (Instructor)", "Login correcto");
        }

        private void FormInstructor_Load(object sender, EventArgs e)
        {
            // Cargar datos o lógica adicional al iniciar el formulario
        }
    }
}

