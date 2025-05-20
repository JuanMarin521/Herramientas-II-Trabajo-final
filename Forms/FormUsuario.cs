using System.Windows.Forms;
using System;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormUsuario : Form
    {
        private Usuario _usuario;

        public FormUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            // Aquí puedes usar _usuario si deseas mostrar datos o validar algo
        }
    }
}

