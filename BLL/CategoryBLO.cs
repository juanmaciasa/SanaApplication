using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CategoryBLO
    {
        public IEnumerable<VIEW_CATEGORIES> GetCategories()
        {
            try
            {
                webshopDBEntities dalOBJ = new webshopDBEntities();
                return dalOBJ.VIEW_CATEGORIES;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CreateProductCategory(int idProduct, int idCategory)
        {
            try
            {
                webshopDBEntities dalOBJ = new webshopDBEntities();
                dalOBJ.SP_RELATIONS(idProduct, idCategory, 1);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
