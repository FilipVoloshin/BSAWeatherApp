﻿using BSAWeatherApp.DataService;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSAWeatherApp.Models
{
    [Table("Cities")]
    public class CityModel : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Name { get; set; }

        public DateTime DateOfCreate { get; set; }
    }
}