using Microsoft.EntityFrameworkCore;
using Task.IRepos;
using Task.Models;

namespace Task.Repos
{
    public class RepoEmployee: IRepoEmployee
    {
        private readonly EmpTaskContext _context;
        public RepoEmployee( EmpTaskContext context)
        {
            _context = context;
        }
        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);

            Save();
        }

        public void Delete(int id)
        {
           var Emp=_context.Employees.FirstOrDefault(e=>e.ID == id);
            if (Emp != null)
            {
                _context.Employees.Remove(Emp);
                Save();
            }
        }

    



        public void Update(Employee employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
             Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
