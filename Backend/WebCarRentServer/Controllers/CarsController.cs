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
    [RoutePrefix("api/cars")]
    public class CarsController : ApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(CarDTO car)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Validtion was failed. Check input data and try again.");

                var service = new CarService();

                await Task.Run(() => service.CreateCar(car));

                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetCar(int id)
        {
            try
            {
                var service = new CarService();

                var car = await Task.Run(() => service.GetCar(id));

                return Ok(car);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("{carCategory:alpha?}/{carsAmounut:int?}")]
        public async Task<IHttpActionResult> GetCars(string carCategory = null, int? carsAmount = null)
        {
            try
            {
                var service = new CarService();

                var cars = await Task.Run(() => service.GetCars(carCategory));

                return Ok(cars);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> EditCar(CarDTO car)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Validtion was failed. Check input data and try again.");

                var service = new CarService();

                await Task.Run(() => service.UpdateCar(car));

                return Ok();

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteCar(int id)
        {
            try
            {
                var service = new CarService();

                await Task.Run(() => service.DeleteCar(id));

                return Ok();

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
