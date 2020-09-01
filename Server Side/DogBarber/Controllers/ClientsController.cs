using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogBarber.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientsBL _IClientsBL;
        public ClientsController(IClientsBL IClientsBL)
        {
            _IClientsBL = IClientsBL;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Clients>> Post([FromBody]Clients newClient )
        {
            return await _IClientsBL.PostClient(newClient);

        }

        //[HttpGet("[action]{Clients}")]
        [HttpPost ("LogIn")]
        public async Task<ActionResult<Clients>> LogIn([FromBody]Clients client)
        {
            Console.WriteLine( "d");
            return await _IClientsBL.GetClient(client);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Clients UpdatedClient)
        {
            return await _IClientsBL.PutClient(id, UpdatedClient);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clients>> Delete(int id)
        {
            return await _IClientsBL.DeleteClient(id);
        }
    }
}
