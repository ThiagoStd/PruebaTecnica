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
    public partial class frmComercioPago : Form
    {
        private transaccion existeTrans;
        public frmComercioPago()
        {
            InitializeComponent();
        }

        #region Botones
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            verificar();
        }
        #endregion
        #region Eventos
        private void frmComercioPago_Load(object sender, EventArgs e)
        {

            cargarDatos();
            cargarCombos();


        }

        private void dgvTrans_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTrans.SelectedRows.Count != 0)
            {
                int idTrans = Convert.ToInt32(dgvTrans.SelectedRows[0].Cells[0].Value.ToString());
                cargarContenido(idTrans);


            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Funciones

        private void cargarDatos()
        {
            comercio existeComercio = _bd.comercios.FirstOrDefault(x => x.id_comercio == _user);
            lblTitulo.Text = existeComercio.comercio_nombre.ToString();
            lblnit.Text = existeComercio.comercio_nit.ToString();
            lbldireccion.Text = existeComercio.comercio_direccion.ToString();

            dgvTrans.DataSource = _bd.transacciones.Where(x => x.trans_comercio == _user).ToList();
            dgvTrans.Columns["Id_Trans"].Visible = false;
            dgvTrans.Columns["usuario"].Visible = false;
            dgvTrans.Columns["comercio"].Visible = false;
            dgvTrans.Columns["medios_pago"].Visible = false;
            dgvTrans.Columns["estado"].Visible = false;
        }
        #endregion

        /// <summary>
        /// Carga los combobox
        /// </summary>
        private void cargarCombos()
        {
            try
            {
                //Metodos de pago
                var mediosPago = _bd.medios_pago.ToList();

                cbMetodo.DataSource = mediosPago;
                cbMetodo.DisplayMember = "pago_nombre";
                cbMetodo.ValueMember = "id_pago";

                //Estados
                var estados = _bd.estados.ToList();

                cbEstado.DataSource = estados;
                cbEstado.DisplayMember = "estado_nombre";
                cbEstado.ValueMember = "id_estado";

                //Usuarios
                var usuarios = _bd.usuarios.ToList();

                cbUsuario.DataSource = usuarios;
                cbUsuario.DisplayMember = "usuario_nombre";
                cbUsuario.ValueMember = "id_usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los combos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// verifica los datos antes de actualizar
        /// </summary>
        private void verificar()
        {
            try
            {
                if (txtConcepto.Text == "")
                {
                    ; throw new Exception("El concepto esta vacio");
                }

                if (txtValor.Text == "")
                {
                    ; throw new Exception("El valor esta vacio");
                }
                actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// cargar contenido de la tabla seleccionada
        /// </summary>
        /// <param name="idTrans"></param>
        private void cargarContenido(int idTrans)
        {
            try
            {
                existeTrans = _bd.transacciones.FirstOrDefault(x => x.id_trans == idTrans);
                cbUsuario.SelectedValue = existeTrans.trans_usuario;
                cbMetodo.SelectedValue = existeTrans.trans_medio_pago;
                cbEstado.SelectedValue = existeTrans.trans_estado;
                txtConcepto.Text = existeTrans.trans_concepto.ToString();
                txtValor.Text = existeTrans.trans_total.ToString();

                if (cbEstado.Text == "Aprobada")
                {
                    cbUsuario.Enabled = true;
                    cbMetodo.Enabled = true;
                    cbEstado.Enabled = true;
                    txtValor.Enabled = true;
                    btnActualizar.Enabled = true;
                    txtConcepto.Enabled = true;
                }
                else
                {
                    cbUsuario.Enabled = false;
                    cbMetodo.Enabled = false;
                    cbEstado.Enabled = false;
                    txtValor.Enabled = false;
                    btnActualizar.Enabled = false;
                    txtConcepto.Enabled = false;   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la información: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// actualiza el registro seleccionado
        /// </summary>
        private void actualizar()
        {
            try
            {
                var fechaActual = _bd.Database.SqlQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();

                existeTrans.trans_medio_pago = Convert.ToInt32(cbMetodo.SelectedValue);
                existeTrans.trans_estado = Convert.ToInt32(cbEstado.SelectedValue);
                existeTrans.trans_usuario = Convert.ToInt32(cbUsuario.SelectedValue);
                existeTrans.trans_total = Convert.ToDecimal(txtValor.Text);
                existeTrans.trans_fecha = fechaActual.ToString();
                existeTrans.trans_concepto = txtConcepto.Text;

                _bd.Entry(existeTrans).State = EntityState.Modified;
                _bd.SaveChanges();
                MessageBox.Show("Pago actualizado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbUsuario.Enabled = false;
                cbMetodo.Enabled = false;
                cbEstado.Enabled = false;
                txtValor.Enabled = false;
                btnActualizar.Enabled = false;
                cargarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el pago: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
