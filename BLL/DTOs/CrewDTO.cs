﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HometaskEntity.DAL.Models;


namespace HometaskEntity.BLL.DTOs
{
    public class CrewDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Aviator aviator { get; set; }
        [Required]
        public List<Stewardess> stewardesses { get; set; }
    }
}
