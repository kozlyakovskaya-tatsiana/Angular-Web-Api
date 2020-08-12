using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class CarRentContext: DbContext
    {
        public CarRentContext() : base("DbConnection") { }

        DbSet<Car> Cars { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<CarRent> CarRents { get; set; }
    }
}
