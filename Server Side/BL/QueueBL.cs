using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class QueueBL : IQueueBL
    {
        IQueueDL _IQueueDL;
        public QueueBL(IQueueDL IQueueDL)
        {
            _IQueueDL = IQueueDL;
        }
        public async Task<ActionResult<Queue>> DeleteQueue(int id)
        {
            return await _IQueueDL.DeleteQueue(id);
        }

        public async Task<ActionResult<Queue>> GetAppointment(int id)
        {
            return await _IQueueDL.GetAppointment(id);
        }

        public Task<ActionResult<IEnumerable<AppointmentDetails>>> GetQueue()
        {
            return _IQueueDL.GetQueue();
        }

        public async Task<ActionResult<AppointmentDetails>> PostQueue(Queue newQueue)
        {
            return await _IQueueDL.PostQueue(newQueue);
        }
        public async Task<IActionResult> PutQueue(int id, Queue updatedQueue)
        {
            return await _IQueueDL.PutQueue(id, updatedQueue);
        }


    }
}
