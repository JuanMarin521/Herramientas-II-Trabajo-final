using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Repositories;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioRepository usuarioRepository = new UsuarioRepository();

        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contraseña = txtPassword.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = usuarioRepository.ValidarCredenciales(nombreUsuario, contraseña);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {usuario.Nombre}. Rol: {usuario.Rol}", "Éxito");

                this.Hide();

                // Abrir el formulario correspondiente según el rol
                switch (usuario.Rol)
                {
                    case "Administrador":
                        new FormAdministrador(usuario).Show();
                        break;
                    case "Instructor":
                        new FormInstructor(usuario).Show();
                        break;
                    case "Cliente":
                        new FormCliente(usuario).Show(); 
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
