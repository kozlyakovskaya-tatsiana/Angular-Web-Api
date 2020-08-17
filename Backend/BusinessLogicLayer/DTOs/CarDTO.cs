using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string Carcase { get; set; }

        public int MaxPassengersAmount { get; set; }

        public string ImgSrc { get; set; }

        public string CategoryName { get; set; }

        public double CostRentForDay { get; set; }
    }
}
