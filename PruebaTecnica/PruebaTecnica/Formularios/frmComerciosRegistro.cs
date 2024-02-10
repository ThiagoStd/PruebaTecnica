using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PruebaTecnica.Variables;
namespace PruebaTecnica.Formularios
{
    public partial class frmComerciosRegistro : Form
    {
        public comercio existeComercio;
        public frmComerciosRegistro()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmComerciosRegistro_Load(object sender, EventArgs e)
        {
            if (existeComercio != null)
            {
                cargarComercioRegistrado();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
             
                e.Handled = true;
            }
        }
        #endregion

        #region Botones
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (existeComercio != null)
            {
                actualizarContra();

            }
            else
            {
                Verificar();
            }
        }
        #endregion

        #region Funciones

        /// <summary>
        /// Verificar datos a ingresar
        /// </summary>
        private void Verificar()
        {
            try
            {
                if (txtCodigo.Text == "")
                {
                    ; throw new Exception("El código esta vacio");
                }

                if (txtNombre.Text == "")
                {
                    ; throw new Exception("El nombre esta vacio");
                }

                if (txtNit.Text == "")
                {
                    ; throw new Exception("El Nit esta vacio");
                }

                if (txtContra.Text == "")
                {
                    ; throw new Exception("La contraseña esta vacia");
                }

                if (txtdireccion.Text == "")
                {
                    ; throw new Exception("la dirección esta vacia");
                }

                // Se verifica si ya existe el comercio
                int comercioCodigo = Convert.ToInt32(txtCodigo.Text);
                comercio existeComercio = _bd.comercios.FirstOrDefault(x => x.comercio_codigo == comercioCodigo);

                if (existeComercio == null)
                {
                    guardarComercio();
                }
                else
                {
                    MessageBox.Show($"El Comercio ya existe en la base datos. ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guardar la información del comercio
        /// </summary>
        private void guardarComercio()
        {
            try
            {
                string ClaveHasehada = ObtenerHash(txtContra.Text);
                comercio infoComercio = new comercio
                {
                    comercio_codigo = Convert.ToInt32(txtCodigo.Text),
                    comercio_nombre = txtNombre.Text,
                    comercio_clave = ClaveHasehada,
                    comercio_nit = txtNit.Text,
                    comercio_direccion = txtdireccion.Text
                };
                _bd.comercios.Add(infoComercio);
                _bd.SaveChanges();
                MessageBox.Show("Comercio creado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var frmInicio = new frmIniciarSesion();
                frmInicio.usuario = txtCodigo.Text;
                frmInicio.tipo = "Comercio";
                frmInicio.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Carga la información del comercio encontrado
        /// </summary>
        private void cargarComercioRegistrado()
        {
            try
            {
                this.Text = "Crear Contraseña";
                lblTitulo.Text = "Crear Contraseña";
                btnCrear.Text = "Registar Contraseña";

                txtCodigo.Text = existeComercio.comercio_codigo.ToString();
                txtNombre.Text = existeComercio.comercio_nombre;
                txtNit.Text = existeComercio.comercio_nit;
                txtdireccion.Text = existeComercio.comercio_direccion;

                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                txtNit.Enabled = false;
                txtdireccion.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el comercio: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Actualiza la contraseña del comercio
        /// </summary>
        private void actualizarContra()
        {
            try
            {
                if (txtContra.Text != "")
                {
                    string ClaveHasehada = ObtenerHash(txtContra.Text);
                    existeComercio.comercio_clave = ClaveHasehada;
                    _bd.Entry(existeComercio).State = EntityState.Modified;
                    _bd.SaveChanges();
                    MessageBox.Show("Contraseña actualizada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var frmInicio = new frmIniciarSesion();
                    frmInicio.usuario = existeComercio.comercio_codigo.ToString();
                    frmInicio.tipo = "Comercio";
                    frmInicio.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("La contraseña no puede estar vacia ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la contraseña: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        
    }



}
