//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Product
    {
        public Product()
        {
            this.Order = new HashSet<Order>();
            this.Category = new HashSet<Category>();
        }
    
        public decimal Product_id { get; set; }
        [Display(Name = "Title")]
        public string Product_title { get; set; }
        [Display(Name = "Price")]
        public Nullable<long> Product_price { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
