using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkModels.Repositories
{
    public class CarRentRepository: IRepository<CarRent>
    {
        private CarRentContext _db;

        public CarRentRepository(CarRentContext context)
        {
            _db = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void Create(CarRent item)
        {
            if (item != null)
            {
                _db.CarRents.Add(item);
            }
            else
                throw new ArgumentNullException(nameof(item));
        }

        public void Delete(int id)
        {
            var item = _db.CarRents.Find(id) ??
                 throw new Exception($"CarRent with id={id} is not found.");

            _db.CarRents.Remove(item);
        }

        public CarRent Get(int id)
        {
            return _db.CarRents.Find(id) ??
                throw new Exception($"CarRent with id={id} is not found.");
        }

        public IQueryable<CarRent> GetAll()
        {
            return _db.CarRents;
        }

        public void Update(CarRent item)
        {
            if (item != null)
            {
                _db.CarRents.AddOrUpdate(item);
            }
            else
                throw new ArgumentNullException(nameof(item));
        }
    }
}
