using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkModels.Repositories
{
    public class CarCategoryRepository: IRepository<CarCategory>
    {
        private CarRentContext _db;

        public CarCategoryRepository(CarRentContext context)
        {
            _db = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void Create(CarCategory item)
        {
            if (item != null)
            {
                _db.CarCategories.Add(item);
            }
            else
                throw new ArgumentNullException(nameof(item));

        }

        public void Delete(int id)
        {
            var item = _db.CarCategories.Find(id) ??
                 throw new Exception($"Car category with id={id} is not found.");

            _db.CarCategories.Remove(item);
        }

        public CarCategory Get(int id)
        {
            return _db.CarCategories.Include(carCtgr=> carCtgr.Cars).Where(carctgr=> carctgr.Id == id).FirstOrDefault() ??
                throw new Exception($"Car category with id={id} is not found.");
        }

        public IQueryable<CarCategory> GetAll()
        {
            return _db.CarCategories.Include(carCtgr=> carCtgr.Cars);
        }

        public void Update(CarCategory item)
        {
            if (item != null)
            {
                if (_db.CarCategories.Find(item.Id) == null)
                    throw new Exception($"Car category with id={item.Id} is not found.");

                _db.Entry(item).State = EntityState.Modified;
            }
            else
                throw new ArgumentNullException(nameof(item));
        }
    }
}
