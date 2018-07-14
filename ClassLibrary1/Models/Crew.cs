using System;
using System.Collections.Generic;
using System.Text;

namespace HometaskEntity.DAL.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public Aviator aviator { get; set; }
        public List<Stewardess> stewardesses { get; set; }
    }
}
