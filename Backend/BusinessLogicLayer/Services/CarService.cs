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

                car.Category = category;

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

    }
}
