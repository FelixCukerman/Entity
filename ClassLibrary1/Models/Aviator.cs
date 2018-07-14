using System;
using System.ComponentModel.DataAnnotations;

namespace HometaskEntity.DAL.Models
{
    public class Aviator
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int Experience { get; set; }
    }
}
