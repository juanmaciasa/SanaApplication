using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Objects;

namespace BLL
{
    public class ProductBLO
    {
        public bool CreateProduct(string title, long price, ref string error)
        {
            try
            {
                ObjectParameter id = new ObjectParameter("Inserted", typeof(int));
                webshopDBEntities dalOBJ = new webshopDBEntities();
                dalOBJ.SP_PRODUCT_ACTIONS(0, title, price, 1, id);
                error = id.Value.ToString();
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public bool UpdateProduct(int id, string title, long price, ref string error)
        {
            try
            {
                ObjectParameter idP = new ObjectParameter("@Inserted", typeof(int));
                webshopDBEntities dalOBJ = new webshopDBEntities();
                dalOBJ.SP_PRODUCT_ACTIONS(id, title, price, 2, idP);
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public bool DeleteProduct(int id, ref string error)
        {
            try
            {
                ObjectParameter idP = new ObjectParameter("@Inserted", typeof(int));
                webshopDBEntities dalOBJ = new webshopDBEntities();
                dalOBJ.SP_PRODUCT_ACTIONS(id, "", 0, 3, idP);
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public IEnumerable<VIEW_PRODUCTS> GetProducts()
        {
            try
            {
                webshopDBEntities dalOBJ = new webshopDBEntities();
                IEnumerable<VIEW_PRODUCTS> products = dalOBJ.VIEW_PRODUCTS;
                return products;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
