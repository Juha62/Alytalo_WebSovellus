//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlytaloWebSovellus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TalonLammot
    {
        public int HuoneId { get; set; }
        public string Huone { get; set; }
        public int TavoiteLampoTila { get; set; }
        public int TalonNykyLampoTila { get; set; }
        public Nullable<System.DateTime> PaivaMaara { get; set; }
    }
}
