using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebCarRentServer.Controllers
{
    public class CarCategoriesController : ApiController
    {
        public IHttpActionResult GetCarCategories()
        {
            try
            {
                var service = new CarCategoryService();

                var categories = service.GetCarCategories();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
