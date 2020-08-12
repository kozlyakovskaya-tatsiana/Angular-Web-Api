using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CarRent
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateStartRent { get; set; }

        [Required]
        public int DaysRentAmount { get; set; }

        
        public int? CarId { get; set; }

        public Car Car { get; set; }

        
        public int? ClientId { get; set; }

        public Client Client { get; set; }
    }
}
