namespace SimpleCalendar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
