using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork.Repositories
{
    internal class CarRepository : IRepository<Car>
    {
        private CarRentContext _db;

        public CarRepository(CarRentContext context)
        {
            _db = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void Create(Car item)
        {
            if (item != null)
            {
                _db.Cars.Add(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public void Delete(int id)
        {
            var item = _db.Cars.Find(id) ??
                 throw new Exception($"Car with id={id} is not found.");

            _db.Cars.Remove(item);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Car Get(int id)
        {
            return _db.Cars.Find(id) ??
                throw new Exception($"Car with id={id} is not found.");
        }

        public IEnumerable<Car> GetAll()
        {
            return _db.Cars.ToArray();
        }

        public void Update(Car item)
        {
            if (item != null)
            {
                _db.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
