//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDesktop1.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class datos
    {
        public int id { get; set; }
        public string producto { get; set; }
        public Nullable<int> valor { get; set; }
        public int fk_usuarios { get; set; }
    
        public virtual usuarios usuarios { get; set; }
    }
}
