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

    public partial class frmUsuarioRegistro : Form
    {
        public usuario existeUsuario;
        public frmUsuarioRegistro()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmUsuarioRegistro_Load(object sender, EventArgs e)
        {
            if (existeUsuario != null)
            {
                cargarUsuarioRegistrado();
            }
        }
        #endregion

        #region Botones
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (existeUsuario != null)
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
                if (txtUsuario.Text == "")
                {
 ;                   throw new Exception("La identificación esta vacia");
                }

                if (txtNombre.Text == "")
                {
                    ; throw new Exception("El nombre esta vacio");
                }

                if (txtContra.Text == "")
                {
                    ; throw new Exception("La contraseña esta vacia");
                }

                if (txtCorreo.Text == "")
                {
                    ; throw new Exception("El correo esta vacio");
                }

                // Se verifica si ya existe el usuario
                var usuarioidentificacion = txtUsuario.Text;
                usuario existeUsuario = _bd.usuarios.FirstOrDefault(x => x.usuario_identificacion == usuarioidentificacion);

                if (existeUsuario == null)
                {
                    guardarUsuario();
                }
                else
                {
                    MessageBox.Show($"El usuario ya existe en la base datos. ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guardar la información del usuario
        /// </summary>
        private void guardarUsuario()
        {
            try
            {
                usuario infoUsuario = new usuario
                {
                    usuario_identificacion = txtUsuario.Text,
                    usuario_nombre = txtNombre.Text,
                    usuario_clave = txtContra.Text,
                    usuario_email = txtCorreo.Text
                };
                _bd.usuarios.Add(infoUsuario);
                _bd.SaveChanges();
                MessageBox.Show("Usuario correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var frmInicio = new frmIniciarSesion();
                frmInicio.usuario = txtUsuario.Text;
                frmInicio.tipo = "Pagador";
                frmInicio.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Carga la información del usuario encontrado
        /// </summary>
        private void cargarUsuarioRegistrado()
        {
            try
            {
                this.Text = "Crear Contraseña";
                lblTitulo.Text = "Crear Contraseña";
                btnCrear.Text = "Registar Contraseña";

                txtUsuario.Text = existeUsuario.usuario_identificacion;
                txtNombre.Text = existeUsuario.usuario_nombre;
                txtCorreo.Text = existeUsuario.usuario_email;

                txtUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtCorreo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el usuario: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        
        /// <summary>
        /// Actualiza la contraseña del usuario
        /// </summary>
        private void actualizarContra()
        {
            try
            {
                if (txtContra.Text != "") {

                    existeUsuario.usuario_clave = txtContra.Text;
                    _bd.Entry(existeUsuario).State = EntityState.Modified;
                    _bd.SaveChanges();
                    MessageBox.Show("Contraseña actualizada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var frmInicio = new frmIniciarSesion();
                    frmInicio.usuario = existeUsuario.usuario_identificacion.ToString();
                    frmInicio.tipo = "Pagador";
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
