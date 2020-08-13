using DataAccessLayer.EF;
using DataAccessLayer.UnitOfWorkModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkModels
{
    public class UnitOfWork : IDisposable
    {
        private CarRentContext _db;

        private CarRepository _carRepository;

        private ClientRepository _clientRepository;

        private CarRentRepository _carRentRepository;

        public UnitOfWork()
        {
            _db = new CarRentContext();
        }
        public CarRepository Cars
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_db);

                return _carRepository;

            }
        }

        public ClientRepository Clients
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_db);

                return _clientRepository;
            }
        }

        public CarRentRepository CarRents
        {
            get
            {
                if (_carRentRepository == null)
                    _carRentRepository = new CarRentRepository(_db);

                return _carRentRepository;
            }
        }

        public void Save()
        {
            this._db.SaveChanges();
        }

        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
