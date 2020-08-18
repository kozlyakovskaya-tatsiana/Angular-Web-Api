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
                if (ModelState.IsValid)
                {
                    var service = new CarService();

                    await Task.Run(() => service.CreateCar(car));

                    return Ok();
                }
                else
                {
                    return BadRequest("Validtion was failed. Check input data and try again.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route("{id}")]
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
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("{carCategory:alpha=}")]
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

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> EditCar(CarDTO car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new CarService();

                    await Task.Run(() => service.UpdateCar(car));

                    return Ok();
                }
                else
                {
                    return BadRequest("Validtion was failed. Check input data and try again.");
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
