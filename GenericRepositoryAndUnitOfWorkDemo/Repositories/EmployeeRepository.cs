using GenericRepositoryAndUnitOfWorkDemo.Data;
using GenericRepositoryAndUnitOfWorkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryAndUnitOfWorkDemo.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        // Employee entity functions 
    }

    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DatabaseContext db;
        private readonly IUnitOfWork uow;

        public EmployeeRepository(DatabaseContext db, IUnitOfWork uow) : base(db, uow)
        {
            this.db = db;
            this.uow = uow;
        }

        // Employee entity functions 
    }
}
