﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSAWeatherApp.Models
{
    [Table("CityHistory")]
    public class CityHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        public DateTime DateTimeOfSearch { get; set; }
    }
}