using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleCalendar.Models;

namespace SimpleCalendar.Controllers
{
    public class AppointmentsAPIController : ApiController
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: api/AppointmentsAPI
        public IQueryable<Appointment> GetAppointments()
        {
            return db.Appointments;
        }

        // GET: api/AppointmentsAPI/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        
        public IQueryable<Appointment> GetMonthAppointments(int month)
        {
            db.Appointments.AsNoTracking();
            IQueryable<Appointment> appointments = db.Appointments.Include(item=>item.Attendees).Where(i=>i.Date.HasValue && i.Date.Value.Month == month);
            return appointments;
        }
        // PUT: api/AppointmentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.Id)
            {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppointmentsAPI
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(appointment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AppointmentExists(appointment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/AppointmentsAPI/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id)
        {
            return db.Appointments.Count(e => e.Id == id) > 0;
        }
    }
}