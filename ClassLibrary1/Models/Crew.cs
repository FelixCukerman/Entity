using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HometaskEntity.DAL.Models
{
    public class Crew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Aviator aviator { get; set; }
        public List<Stewardess> stewardesses { get; set; }
    }
}
