//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OriginChellenge.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operacion
    {
        public long IdOperacion { get; set; }
        public long IdTipoOperacion { get; set; }
        public long IdTarjeta { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Tarjeta Tarjeta { get; set; }
        public virtual TipoOperacion TipoOperacion { get; set; }
    }
}