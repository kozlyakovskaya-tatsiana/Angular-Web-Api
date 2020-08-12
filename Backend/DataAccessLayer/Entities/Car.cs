﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The length of car name must be less than 50 symbols")]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Carsase { get; set; }

        [Required]
        public string MaxPassengersAmount { get; set; }

        [Required]
        public string ImgSrc { get; set; }

        [Required]
        public string Category { get; set; }


        public ICollection<CarRent> CarRents { get; set; }

    }
}
