using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork.Repositories
{
    internal class ClientRepository:IRepository<Client>
    {
        private CarRentContext _db;

        public ClientRepository(CarRentContext context)
        {
            _db = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void Create(Client item)
        {
            if (item != null)
            {
                _db.Clients.Add(item);
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public void Delete(int id)
        {
            var item = _db.Clients.Find(id) ??
                 throw new Exception($"Client with id={id} is not found.");

            _db.Clients.Remove(item);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Client Get(int id)
        {
            return _db.Clients.Find(id) ??
                throw new Exception($"Client with id={id} is not found."); ;
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Clients.ToArray();
        }

        public void Update(Client item)
        {
            if (item != null)
            {
                _db.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
