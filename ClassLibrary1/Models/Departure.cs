using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class Departure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public int TimeOfDeparture { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}
