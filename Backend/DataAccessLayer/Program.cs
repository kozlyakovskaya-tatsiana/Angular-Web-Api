using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ClientRepository(new CarRentContext()))
            {
                db.Delete(3);
                var client = new Client
                {
                    Name = "Tatsiana",
                    Surname = "Kozlyakovskaya",
                    Email = "kozlyakovskaya_tatsiana@mail.ru"
                };
                Console.WriteLine("End");
                // Console.WriteLine(c0.Email);
                Console.ReadKey();

            }

            

        }
    }
}
