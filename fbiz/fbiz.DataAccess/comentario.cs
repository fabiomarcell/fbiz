//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fbiz.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class comentario
    {
        public int comentarioID { get; set; }
        public Nullable<int> produtoID { get; set; }
        public string nome { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public Nullable<System.DateTime> dataCadastro { get; set; }
        public Nullable<bool> ativo { get; set; }
    
        public virtual produto produto { get; set; }
    }
}
