using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
            await ConsumirApiPost();
        }
        #endregion

        #region Funciones

      
        static async Task ConsumirApiPost()
        {
            // URL de la API que deseas consumir
            string apiUrl = "http://pbiz.zonavirtual.com/api/Prueba/Consulta";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
          
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, null);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var strRespuesta = JsonConvert.DeserializeObject(responseBody);
                        //Console.WriteLine(responseBody);
                        MessageBox.Show("Correcto");
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
        #endregion


    }
}
