using GenericRepositoryAndUnitOfWorkDemo.Repositories;

namespace GenericRepositoryAndUnitOfWorkDemo.Data
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext db;

        public UnitOfWork(DatabaseContext db)
        {
            this.db = db;
        }

        private IEmployeeRepository employees;
        public IEmployeeRepository Employees
        {
            get
            {
                if (this.employees == null)
                {
                    this.employees = new EmployeeRepository(db, this);
                }
                return employees;
            }
        }

        private IDepartmentRepository departments;
        public IDepartmentRepository Departments
        {
            get
            {
                if (this.departments == null)
                {
                    this.departments = new DepartmentRepository(db, this);
                }
                return departments;
            }
        }
    }
}
