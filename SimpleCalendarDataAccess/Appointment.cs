namespace SimpleCalendarDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointment
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Organizer { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }
        public virtual ICollection<Employee> Attendees { get;  set; }
    }
}
