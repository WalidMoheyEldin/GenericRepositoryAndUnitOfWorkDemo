using GenericRepositoryAndUnitOfWorkDemo.Data;
using GenericRepositoryAndUnitOfWorkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryAndUnitOfWorkDemo.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        // Department entity functions 
    }

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly DatabaseContext db;
        private readonly IUnitOfWork uow;

        public DepartmentRepository(DatabaseContext db, IUnitOfWork uow) : base(db, uow)
        {
            this.db = db;
            this.uow = uow;
        }

        // Department entity functions 
    }
}
