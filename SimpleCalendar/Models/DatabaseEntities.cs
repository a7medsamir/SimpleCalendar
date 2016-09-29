namespace SimpleCalendar.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                  .HasMany<Appointment>(employee => employee.Appointments)
                  .WithMany(appointment => appointment.Attendees)
                  .Map(appointmentEmployees =>
                  {
                      appointmentEmployees.MapLeftKey("EmployeeId");
                      appointmentEmployees.MapRightKey("AppointmentId");
                      appointmentEmployees.ToTable("Appointment_Employees");
                  });
        }
    }
}
