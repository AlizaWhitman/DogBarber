using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class QueueDL : IQueueDL
    {
        dogBarberShopDBContext _context;

        public QueueDL(dogBarberShopDBContext dogBarberShopDBContext)
        {
            _context = dogBarberShopDBContext;
        }

        public async Task<ActionResult<AppointmentDetails>> PostQueue(Queue newQueue)
        {
            _context.Queue.Add(newQueue);
            await _context.SaveChangesAsync();

            AppointmentDetails newApp = new AppointmentDetails();
            newApp.id = newQueue.id;
            newApp.clientId = newQueue.clientId;
            newApp.userName = _context.Clients.Find(newQueue.clientId).userName;
            newApp.appointmentHour = newQueue.appointmentHour;
            newApp.bookingHour = newQueue.bookingHour;
            return newApp;

        }

        public async Task<IActionResult> PutQueue(int id, Queue updatedQueue)
        {
            updatedQueue.id = id;

            _context.Entry(updatedQueue).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!appointmentExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }


        private bool appointmentExists(int id)
        {

            if (_context.Queue.FindAsync(id) != null)
                return true;
            return false;
        }

        public async Task<ActionResult<Queue>> DeleteQueue(int id)
        {

            var appointmentToDelete = await _context.Queue.FindAsync(id);
            if (appointmentToDelete != null)
            {
                _context.Queue.Remove(appointmentToDelete);
            }

            await _context.SaveChangesAsync();
            return appointmentToDelete;

        }

        public async Task<ActionResult<IEnumerable<AppointmentDetails>>> GetQueue()
        {
            List<AppointmentDetails> appointments = new List<AppointmentDetails>();
            using (var conn = new SqlConnection("Server = DESKTOP-2GVI95M; Database = dogBarberShopDB; Trusted_Connection = True;"))
            {
                using (var cmd = new SqlCommand("SP_getQueue", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        AppointmentDetails newApp = new AppointmentDetails();
                        newApp.id = int.Parse(res["ID"].ToString());
                        newApp.clientId = int.Parse(res["ClientID"].ToString());
                        newApp.userName = res["UserName"].ToString();
                        newApp.appointmentHour = (DateTime)res["AppointmentHour"];
                        newApp.bookingHour = (DateTime)res["BookingHour"];
                        ;
                        appointments.Add(newApp);
                    }

                }

            }
            return appointments;
        }


        public async Task<ActionResult<Queue>> GetAppointment(int id)
        {
            var appointemnt = await _context.Queue.FindAsync(id);
            return appointemnt;
        }
    }

}
