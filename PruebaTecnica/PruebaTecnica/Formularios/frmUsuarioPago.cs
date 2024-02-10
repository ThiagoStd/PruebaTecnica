using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PruebaTecnica.Variables;

namespace PruebaTecnica.Formularios
{
    public partial class frmUsuarioPago : Form
    {
      
        public frmUsuarioPago()
        {
            InitializeComponent();
        }

        #region Eventos
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
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

        private void frmUsuarioPago_Load(object sender, EventArgs e)
        {
            cargarCombos();
        }

        #endregion

        #region Botones
        private void btnCrear_Click(object sender, EventArgs e)
        {
            verificar();
        }
        #endregion

        #region Funciones

        /// <summary>
        /// validación de los datos a ingresar
        /// </summary>
        private void verificar()
        {
            try
            {
                if (txtCodigo.Text == "")
                {
                    ; throw new Exception("El código esta vacio");
                }

                if (txtConcepto.Text == "")
                {
                    ; throw new Exception("El concepto esta vacio");
                }

                if (txtValor.Text == "")
                {
                    ; throw new Exception("El valor esta vacio");
                }


                // Se verifica si ya existe el codigo de la transacción
                int transCodigo = Convert.ToInt32(txtCodigo.Text);
                transaccion existeTrans = _bd.transacciones.FirstOrDefault(x => x.trans_codigo == transCodigo);

                if (existeTrans == null)
                {
                    guardarTransaccion();
                }
                else
                {
                    MessageBox.Show($"El Codigo de la Transacción ya existe en la base datos. ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void guardarTransaccion()
        {
            try
            {
                var fechaActual = _bd.Database.SqlQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();


                transaccion infoTrans = new transaccion
                {
                    trans_codigo = Convert.ToInt32(txtCodigo.Text),
                    trans_medio_pago = Convert.ToInt32(cbMetodo.SelectedValue),
                    trans_estado = Convert.ToInt32(cbEstado.SelectedValue),
                    trans_comercio = Convert.ToInt32(cbComercio.SelectedValue),
                    trans_usuario = _user,
                    trans_total = Convert.ToDecimal(txtValor.Text),
                    trans_fecha = fechaActual.ToString(),
                    trans_concepto = txtConcepto.Text

                };
                _bd.transacciones.Add(infoTrans);
                _bd.SaveChanges();
                MessageBox.Show("Pago creado con exito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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

                //Comercios
                var comercios = _bd.comercios.ToList();

                cbComercio.DataSource = comercios;
                cbComercio.DisplayMember = "comercio_nombre";
                cbComercio.ValueMember = "id_comercio";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los combos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
    
}
