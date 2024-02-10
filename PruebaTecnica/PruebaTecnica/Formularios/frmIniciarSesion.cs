using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PruebaTecnica.Variables;
namespace PruebaTecnica.Formularios
{
    public partial class frmIniciarSesion : Form
    {
        public string usuario;
        public string tipo;
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            if (usuario != "")
            {
                switch (usuario)
                {
                    case "Pagador":
                        rbPagador.Checked = true;
                        break;
                    case "Comercio":
                        rbComercio.Checked = true;
                        break;

                }
                txtUsuario.Text = usuario; 
            }
        }

        private void rbPagador_CheckedChanged(object sender, EventArgs e)
        {
            lblUser.Text = "Identificación";
        }

        private void rbComercio_CheckedChanged(object sender, EventArgs e)
        {
            lblUser.Text = "NIT";
        }

        #endregion

        #region Botones

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            verificarCreado();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var frmUsuario = new frmUsuarioRegistro();
            frmUsuario.ShowDialog();
        }

        #endregion
        #region Funciones
        /// <summary>
        /// Metodo para verificar si existe el usuario
        /// </summary>
        private void verificarCreado()
        {
            string usuario = txtUsuario.Text.Trim();

            try
            {
                if (rbPagador.Checked)
                {
                    usuario existeUsuario = _bd.usuarios.FirstOrDefault(x => x.usuario_identificacion == usuario);

                    if (existeUsuario == null)
                    {
                        if (MessageBox.Show("El usuario no existe desea registrarlo?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var frmUsuario = new frmUsuarioRegistro();
                            frmUsuario.ShowDialog();
                            
                        }
                    }
                    else
                    {
                        if (existeUsuario.usuario_clave.ToString() == "")
                        {
                            if (MessageBox.Show("El usuario se encuentra registrado pero sin contraseña. Desea crearla?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var frmUsuario = new frmUsuarioRegistro();
                                frmUsuario.existeUsuario = existeUsuario;
                                frmUsuario.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                }
                else if (rbComercio.Checked)
                {

                    comercio existeComercio = _bd.comercios.FirstOrDefault(x => x.comercio_nit == usuario);

                    if (existeComercio == null)
                    {
                        if (MessageBox.Show("El comercio no existe desea registrarlo?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var frmComercio = new frmComercioRegistro();
                            frmComercio.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (existeComercio.comercio_clave.ToString() == "")
                        {
                            if (MessageBox.Show("El comercio se encuentra registrado pero sin contraseña. Desea crearla?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var frmComercio = new frmComercioRegistro();
                                frmComercio.existeComercio = existeComercio;
                                frmComercio.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar si existe {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }



        #endregion

      
    }
}
