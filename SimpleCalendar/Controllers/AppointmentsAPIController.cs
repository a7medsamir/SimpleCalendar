using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleCalendarDataAccess;

namespace SimpleCalendar.Controllers
{
    public class AppointmentsAPIController : ApiController
    {
        private CalendarManager calenderManager = new CalendarManager();

        // GET: api/AppointmentsAPI
        public List<Appointment> GetAppointments()
        {
            return calenderManager.GetAppointments();
        }

        // GET: api/AppointmentsAPI/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointment(int id)
        {
            Appointment appointment = calenderManager.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        
        public List<Appointment> GetMonthAppointments(int month)
        {
            return calenderManager.GetMonthAppointments(month);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                calenderManager.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}