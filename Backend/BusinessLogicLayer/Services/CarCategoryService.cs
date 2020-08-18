using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarCategoryService
    {
        public IEnumerable<string> GetCarCategories()
        {
            using (var db = new UnitOfWork())
            {
                return db.CarCategories.GetAll().Select(categoty => categoty.Name).ToArray();
            }
        }

        /*public CarCategory GetCarCategory(string categoryName)
        {
            using (var db = new UnitOfWork())
            {
                return db.CarCategories.GetAll().Where(categoty => categoty.Name == categoryName).FirstOrDefault();
            }
        }*/
    }
}
