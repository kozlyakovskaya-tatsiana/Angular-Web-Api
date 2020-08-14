using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarService
    {
        public IEnumerable<Car> GetCars()
        {
            using (var db = new UnitOfWork())
            {
                return db.Cars.GetAll();
            }
        }
    }
}
