//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcSistem1.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbListe
    {
        public int id { get; set; }
        public Nullable<int> KisiId { get; set; }
        public Nullable<int> SinifId1 { get; set; }
        public Nullable<int> SinifId2 { get; set; }
        public Nullable<int> SinifId3 { get; set; }
        public Nullable<int> SinifId4 { get; set; }
        public Nullable<int> SinifId5 { get; set; }
    
        public virtual tbOgrenci tbOgrenci { get; set; }
        public virtual tbSinif tbSinif { get; set; }
        public virtual tbSinif tbSinif1 { get; set; }
        public virtual tbSinif tbSinif2 { get; set; }
        public virtual tbSinif tbSinif3 { get; set; }
        public virtual tbSinif tbSinif4 { get; set; }
    }
}
