using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebCarRentServer.Controllers
{
    public class CarsController : ApiController
    {
        
        [HttpPost]
        public async Task<IHttpActionResult> Create(CarDTO car)
        {
            try
            {
                var service = new CarService();

                await Task.Run(() => service.CreateCar(car));

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("api/cars/{carCategory=}")]
        public async Task<IHttpActionResult> GetCars(string carCategory)
        {
            try
            {
                 var service = new CarService();

                 var cars = await Task.Run(() => service.GetCars(carCategory));

                 return Ok(cars);
    
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
