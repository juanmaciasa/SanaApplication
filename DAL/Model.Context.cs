﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class webshopDBEntities : DbContext
    {
        public webshopDBEntities()
            : base("name=webshopDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<VIEW_CATEGORIES> VIEW_CATEGORIES { get; set; }
        public DbSet<VIEW_PRODUCTS> VIEW_PRODUCTS { get; set; }
    
        public virtual int SP_PRODUCT_ACTIONS(Nullable<decimal> product_id, string product_title, Nullable<long> product_price, Nullable<int> action, ObjectParameter inserted)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("Product_id", product_id) :
                new ObjectParameter("Product_id", typeof(decimal));
    
            var product_titleParameter = product_title != null ?
                new ObjectParameter("Product_title", product_title) :
                new ObjectParameter("Product_title", typeof(string));
    
            var product_priceParameter = product_price.HasValue ?
                new ObjectParameter("Product_price", product_price) :
                new ObjectParameter("Product_price", typeof(long));
    
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_PRODUCT_ACTIONS", product_idParameter, product_titleParameter, product_priceParameter, actionParameter, inserted);
        }
    
        public virtual int SP_RELATIONS(Nullable<decimal> idOne, Nullable<decimal> idTwo, Nullable<int> action)
        {
            var idOneParameter = idOne.HasValue ?
                new ObjectParameter("IdOne", idOne) :
                new ObjectParameter("IdOne", typeof(decimal));
    
            var idTwoParameter = idTwo.HasValue ?
                new ObjectParameter("IdTwo", idTwo) :
                new ObjectParameter("IdTwo", typeof(decimal));
    
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RELATIONS", idOneParameter, idTwoParameter, actionParameter);
        }
    }
}
