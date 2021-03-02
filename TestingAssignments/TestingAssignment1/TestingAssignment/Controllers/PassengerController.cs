using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestingAssignment.Models;
using TestingAssignment.Repository;
namespace TestingAssignment.Controllers
{
    
    public class PassengerController : ApiController
    {
        private readonly IPassengerRepository _Repo;
        public PassengerController(IPassengerRepository repo)
        {
            _Repo = repo;
        }

        public IList<Passenger> Get()
        {
            return _Repo.getPassengersList();
        }
        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            var obj = _Repo.GetById(id);
            if(obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // POST: api/User
        public Passenger Post([FromBody]Passenger passenger)
        {
            return _Repo.AddPassenger(passenger);
        }

        // PUT: api/User/5
        public Passenger Put([FromBody]Passenger User)
        {
            return _Repo.Update(User);
        }

        // DELETE: api/User/5
        public bool Delete(int id)
        {
            var obj = _Repo.Delete(id);
            return obj;
        }
    }
}
