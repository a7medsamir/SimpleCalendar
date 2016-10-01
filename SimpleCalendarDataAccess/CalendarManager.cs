

namespace SimpleCalendarDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class CalendarManager:IDisposable
    {
        private DatabaseEntities db = new DatabaseEntities();
        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <returns></returns>
        public List<Appointment> GetAppointments()
        {
            return db.Appointments.ToList();
        }
        /// <summary>
        /// Get appointment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Appointment</returns>
        public Appointment GetAppointment(int id)
        {
           return db.Appointments.Find(id);
        }

        /// <summary>
        /// Getl appointments by selected month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Appointment> GetMonthAppointments(int month)
        {
            db.Appointments.AsNoTracking();
            IQueryable<Appointment> appointments = db.Appointments.Include("Attendees").Where(i => i.Date.HasValue && i.Date.Value.Month == month);
            return appointments.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}