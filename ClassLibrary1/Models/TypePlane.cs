using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class TypePlane
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ModelOfPlane { get; set; }
        public int CountOfSeats { get; set; }
        public int CarryingCapacity { get; set; }
    }
}