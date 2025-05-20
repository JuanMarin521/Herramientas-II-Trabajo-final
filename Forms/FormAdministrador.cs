using System.Windows.Forms;
using System;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormAdministrador : Form
    {
        private Usuario _usuario;

        public FormAdministrador(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            // Puedes usar _usuario para mostrar información del administrador
        }
    }
}

