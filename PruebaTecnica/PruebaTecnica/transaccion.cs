//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnica
{
    using System;
    using System.Collections.Generic;
    
    public partial class transaccion
    {
        public int id_trans { get; set; }
        public int trans_codigo { get; set; }
        public int trans_medio_pago { get; set; }
        public int trans_estado { get; set; }
        public int trans_comercio { get; set; }
        public int trans_usuario { get; set; }
        public decimal trans_total { get; set; }
        public System.DateTime trans_fecha { get; set; }
    
        public virtual comercio comercio { get; set; }
        public virtual estado estado { get; set; }
        public virtual medios_pago medios_pago { get; set; }
        public virtual usuario usuario { get; set; }
    }
}