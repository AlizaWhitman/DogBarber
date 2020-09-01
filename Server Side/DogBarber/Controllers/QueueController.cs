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
    public class QueueController : Controller
    {
        private readonly IQueueBL _IQueueBL;
        public QueueController(IQueueBL IQueueBL)
        {
            _IQueueBL = IQueueBL;
        }

        // GET: api/<controller>
        [HttpGet]
        public Task<ActionResult<IEnumerable<AppointmentDetails>>> Get()
        {
            return _IQueueBL.GetQueue();
        }

        // GET: api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Queue>> GetAppointment(int id)
        {
            return await _IQueueBL.GetAppointment(id);

        }
        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<AppointmentDetails>> Post([FromBody]AppointmentDetails newQueue)
        {
            Queue queue = new Queue();
            queue.id = newQueue.id;
            queue.clientId = newQueue.clientId;
            queue.bookingHour = newQueue.bookingHour;
            queue.appointmentHour = newQueue.appointmentHour;
            return await _IQueueBL.PostQueue(queue);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AppointmentDetails UpdatedQueue)
        {
            Queue queue = new Queue();
            queue.id = UpdatedQueue.id;
            queue.clientId = UpdatedQueue.clientId;
            queue.bookingHour = UpdatedQueue.bookingHour;
            queue.appointmentHour = UpdatedQueue.appointmentHour;
            return await _IQueueBL.PutQueue(id, queue);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Queue>> Delete(int id)
        {
            return await _IQueueBL.DeleteQueue(id);
        }
    }
}
