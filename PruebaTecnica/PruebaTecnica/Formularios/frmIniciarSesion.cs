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
            if (tipo != "")
            {
                switch (tipo)
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
            lblUser.Text = "Codigo";
        }

        #endregion

        #region Botones

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            verificarCreado();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rbPagador.Checked)
            {
                var frmUsuario = new frmUsuarioRegistro();
                frmUsuario.ShowDialog();
                this.Close();
            }
            else
            {
                var frmComercio = new frmComerciosRegistro();
                frmComercio.ShowDialog();
                this.Close();
            }
            
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
                        else
                        {
                            string ClaveHasehada = ObtenerHash(txtContra.Text);
                            if (ClaveHasehada == existeUsuario.usuario_clave)
                            {
                                MessageBox.Show("Bienvenido");
                                _user = existeUsuario.id_Usuario;
                                var frmPagoUsuario = new frmUsuarioPago();
                                frmPagoUsuario.ShowDialog();
                                
                            }
                            else
                            {
                                MessageBox.Show("Contraseña Incorrecta", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else if (rbComercio.Checked)
                {
                    int ComercioCodigo = Convert.ToInt32(txtUsuario.Text);
                    comercio existeComercio = _bd.comercios.FirstOrDefault(x => x.comercio_codigo == ComercioCodigo);

                    if (existeComercio == null)
                    {
                        if (MessageBox.Show("El comercio no existe desea registrarlo?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var frmComercio = new frmComerciosRegistro();
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
                                var frmComercio = new frmComerciosRegistro();
                                frmComercio.existeComercio = existeComercio;
                                frmComercio.ShowDialog();
                                this.Close();
                            }
                        }
                        else
                        {
                            string ClaveHasehada = ObtenerHash(txtContra.Text);
                            if (ClaveHasehada == existeComercio.comercio_clave)
                            {

                                MessageBox.Show("Bienvenido");
                                _user = existeComercio.id_comercio;
                                var frmPagoComercio = new frmComercioPago();
                                frmPagoComercio.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña Incorrecta", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
