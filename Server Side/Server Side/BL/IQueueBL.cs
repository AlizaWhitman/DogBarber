﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IQueueBL
    {
        Task<ActionResult<Queue>> DeleteQueue(int id);
        Task<ActionResult<IEnumerable<AppointmentDetails>>> GetQueue();
        Task<ActionResult<AppointmentDetails>> PostQueue(Queue newQueue);
        Task<IActionResult> PutQueue(int id, Queue updatedQueue);
        Task<ActionResult<Queue>> GetAppointment(int id);
    }
}