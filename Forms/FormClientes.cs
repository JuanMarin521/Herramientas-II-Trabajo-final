using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Repositories;
using Trabajo_final_herramientas_II.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trabajo_final_herramientas_II
{
    public partial class FormClientes : Form
    {
        private readonly ClienteRepository _clienteRepository;
        private int clienteSeleccionadoID = -1;

        public FormClientes()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMembresia.SelectedIndex = 0;

            CargarClientes();
        }


        private void CargarClientes()
        {
            var lista = _clienteRepository.ObtenerTodos();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["ClienteID"].Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;


            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                TipoMembresia = cmbMembresia.SelectedItem.ToString()
            };

            if (_clienteRepository.Insertar(cliente))
            {
                MessageBox.Show("Cliente agregado exitosamente.");
                LimpiarCampos();
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Error al agregar cliente.");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoID == -1)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            Cliente cliente = new Cliente
            {
                ClienteID = clienteSeleccionadoID,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                TipoMembresia = cmbMembresia.SelectedItem.ToString()
            };

            if (_clienteRepository.Actualizar(cliente))
            {
                MessageBox.Show("Cliente actualizado.");
                LimpiarCampos();
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Error al actualizar.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dataGridView1.Rows[e.RowIndex];

                clienteSeleccionadoID = Convert.ToInt32(fila.Cells["ClienteID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                cmbMembresia.SelectedItem = fila.Cells["TipoMembresia"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoID == -1)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show("¿Seguro que deseas eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                if (_clienteRepository.Eliminar(clienteSeleccionadoID))
                {
                    MessageBox.Show("Cliente eliminado.");
                    LimpiarCampos();
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar.");
                }
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            cmbMembresia.SelectedIndex = 0;
            clienteSeleccionadoID = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.");
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El campo Teléfono es obligatorio.");
                txtTelefono.Focus();
                return false;
            }
            if (cmbMembresia.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de membresía.");
                cmbMembresia.Focus();
                return false;
            }
            return true;
        }
    }
    // Update the Cliente class to include the ClienteID property
    public class Cliente : Usuario
    {
        public int ClienteID { get; set; } // Add this property
        public string TipoMembresia { get; set; }
        public override void MostrarPermisos() { }
    }
}
