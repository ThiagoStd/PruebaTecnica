using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaTecnica.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PruebaTecnica.Variables;

namespace PruebaTecnica
{
    public partial class frmInicial : Form
    {
    #region Eventos
        public frmInicial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    #endregion

    #region Botones
        private async void btnCargar_Click(object sender, EventArgs e)
        {
            btnSesion.Enabled = false;
            await ConsumirApiPost();
            btnSesion.Enabled = true;
        }

        private void btnSesion_Click(object sender, EventArgs e)
        {
            var frmSesion = new frmIniciarSesion();
            frmSesion.ShowDialog();
            this.Close();
        }
        #endregion

    #region Funciones

        /// <summary>
        /// Metodo para consumir el API
        /// </summary>
        /// <returns></returns>
        static async Task ConsumirApiPost()
        {
            
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(_apiUrl, null);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var objRespuesta = JsonConvert.DeserializeObject(responseBody);
                        var arreglo = ((Newtonsoft.Json.Linq.JContainer)objRespuesta);
            
                        foreach (var dato in arreglo.ToArray())
                        {
                            // Se envia la información para ser procesada
                            AlimentarBD(dato);
                        }
                        MessageBox.Show("Proceso Exitoso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                          MessageBox.Show($"Ocurrió un error al solicitar la información. Error: {response.StatusCode}. Pruebe de nuevo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consumir la API: {ex.Message}. Pruebe de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///  Metodo para alimentar la base de datos
        /// </summary>
        /// <param name="dato"> Arreglo tipo JToken</param>
        static void AlimentarBD(JToken dato)
        {
            try
            {
                
                //PROCESO PARA GUARDAR LOS COMERCIOS
                comercio infoComercio = new comercio
                {
                    comercio_codigo = Convert.ToInt32(dato["comercio_codigo"].ToString()),
                    comercio_nombre = dato["comercio_nombre"].ToString(),
                    comercio_nit = dato["comercio_nit"].ToString(),
                    comercio_clave = "",
                    comercio_direccion = dato["comercio_direccion"].ToString()
                };
                // Se verifica si ya existe el comercio
                int comerciocodigo = Convert.ToInt32(dato["comercio_codigo"]);
                comercio existeComercio = _bd.comercios.FirstOrDefault(x => x.comercio_codigo == comerciocodigo);

                //Si no se encuentra el comercio se inserta
                if (existeComercio == null)
                {
                    _bd.comercios.Add(infoComercio);
                    _bd.SaveChanges();
                }

                //PROCESO PARA GUARDAR LOS USUARIOS
                usuario infoUsuario = new usuario
                {
                    usuario_identificacion = dato["usuario_identificacion"].ToString(),
                    usuario_nombre = dato["usuario_nombre"].ToString(),
                    usuario_clave = "",
                    usuario_email = dato["usuario_email"].ToString()
                };
                // Se verifica si ya existe el usuario
                var usuarioidentificacion = dato["usuario_identificacion"].ToString();
                usuario existeUsuario = _bd.usuarios.FirstOrDefault(x => x.usuario_identificacion == usuarioidentificacion);

                //Si no se encuentra el usuario se inserta
                if (existeUsuario == null)
                {
                    _bd.usuarios.Add(infoUsuario);
                    _bd.SaveChanges();
                }

                //PROCESO PARA GUARDAR LAS TRANSACCIONES

                // Se consultan los ids para la relacciones

                //Id Medio de pago
                int metodoCodigo = Convert.ToInt32(dato["Trans_medio_pago"].ToString());
                medios_pago existeMetodo = _bd.medios_pago.FirstOrDefault(x => x.pago_codigo == metodoCodigo);
                int idMedioPago = existeMetodo.id_pago;

                //Id Estado
                int idEstado;
                short estadoCodigo = Convert.ToInt16(dato["Trans_estado"].ToString());
                estado existeEstado = _bd.estados.FirstOrDefault(x => x.estado_codigo == estadoCodigo);

                if (existeEstado == null) {

                    estado infoEstado = new estado
                    { 
                        estado_codigo = estadoCodigo,
                        estado_nombre = "Estado "+estadoCodigo
                    };
                    _bd.estados.Add(infoEstado);
                    _bd.SaveChanges();
                    existeEstado = _bd.estados.FirstOrDefault(x => x.estado_codigo == estadoCodigo);
                }
                idEstado = existeEstado.id_estado;

                //Id Comercio
                int idComercio;
                if (existeComercio == null)
                {
                    existeComercio = _bd.comercios.FirstOrDefault(x => x.comercio_codigo == comerciocodigo);
                    idComercio = existeComercio.id_comercio;

                }
                else
                {
                    idComercio = existeComercio.id_comercio;
                }

                //Id Usuario
                int idUsuario;
                if (existeUsuario == null)
                {

                    existeUsuario = _bd.usuarios.FirstOrDefault(x => x.usuario_identificacion == usuarioidentificacion);
                    idUsuario = existeUsuario.id_Usuario;
                }
                else
                {
                    idUsuario = existeUsuario.id_Usuario;
                }

                // Se verifica si ya existe el codigo de la transaccion
                int transCodigo = Convert.ToInt32(dato["Trans_codigo"].ToString());
                transaccion existeTrans = _bd.transacciones.FirstOrDefault(x => x.trans_codigo == transCodigo);


                // Si no existe la transaccion se inserta
                if (existeTrans == null)
                {
                    transaccion infoTrasaccion = new transaccion
                    {
                        trans_codigo = Convert.ToInt32(dato["Trans_codigo"].ToString()),
                        trans_medio_pago = idMedioPago,
                        trans_estado = idEstado,
                        trans_comercio = idComercio,
                        trans_usuario = idUsuario,
                        trans_total = Convert.ToDecimal(dato["Trans_total"].ToString()),
                        trans_fecha = dato["Trans_fecha"].ToString(),
                        trans_concepto = dato["Trans_concepto"].ToString()

                    };
                    _bd.transacciones.Add(infoTrasaccion);
                    _bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al insertar los datos: {ex.Message}. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        #endregion

      
    }
}
