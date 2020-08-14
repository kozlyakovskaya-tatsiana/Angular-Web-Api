using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebCarRentServer.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var service = new ClientService();
            return Ok(service.GetAll());

        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Client client;
                using (var db = new UnitOfWork())
                {
                    client = db.Clients.Get(id);
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
