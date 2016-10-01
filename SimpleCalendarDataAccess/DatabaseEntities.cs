namespace SimpleCalendarDataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntitiesConnection")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //mapping relation between appointment table and employees tab;e
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
