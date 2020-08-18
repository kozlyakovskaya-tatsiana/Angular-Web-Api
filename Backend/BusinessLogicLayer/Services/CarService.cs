using AutoMapper;
using BusinessLogicLayer.DTOs;
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
        public void CreateCar(CarDTO carDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, Car>());

            var mapper = new Mapper(config);

            var car = mapper.Map<CarDTO, Car>(carDTO);

            var carCategoryservice = new CarCategoryService();

            using (var db = new UnitOfWork())
            {
                var category = db.CarCategories.GetAll().Where(ctgr => ctgr.Name == carDTO.CategoryName).FirstOrDefault();

                car.CategoryId = category.Id;

                db.Cars.Create(car);

                db.Save();
            }
        }

        public IEnumerable<CarDTO> GetCars(string carCategory)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>().
                        ForMember("CategoryName", opt => opt.MapFrom(car => car.Category.Name)));

            var mapper = new Mapper(config);

            using (var db = new UnitOfWork())
            {
                if (string.IsNullOrEmpty(carCategory))
                    return mapper.Map<CarDTO[]>(db.Cars.GetAll());

                return mapper.Map<CarDTO[]>(db.Cars.GetAll().Where(car => car.Category.Name == carCategory));
            }
        }

        public CarDTO GetCar(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>().
                         ForMember("CategoryName", opt => opt.MapFrom(car => car.Category.Name)));

            var mapper = new Mapper(config);

            using (var db = new UnitOfWork())
            {
                return mapper.Map<CarDTO>(db.Cars.Get(id));
            }
        }

        public void UpdateCar(CarDTO carDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, Car>());

            var mapper = new Mapper(config);

            var car = mapper.Map<Car>(carDTO);

            using (var db = new UnitOfWork())
            {
                var category = db.CarCategories.GetAll().Where(ctgry => ctgry.Name == carDTO.CategoryName).FirstOrDefault();

                car.CategoryId = category.Id;

                db.Cars.Update(car);

                db.Save();
            }
        }

    }
}
