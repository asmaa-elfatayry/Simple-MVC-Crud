using Task.IRepos;
using Task.Models;

namespace Task.Repos
{
    public class RepoDepartment : IRepoDepartment
    {
        private readonly EmpTaskContext _context;
        public RepoDepartment(EmpTaskContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
    }
}
