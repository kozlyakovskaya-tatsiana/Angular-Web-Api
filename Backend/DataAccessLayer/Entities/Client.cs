using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The length of name must be less than 50")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The length of surname must be less than 50")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public ICollection<CarRent> CarRents { get; set; }
    }
}
