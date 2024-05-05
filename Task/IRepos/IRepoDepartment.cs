using Task.Models;

namespace Task.IRepos
{
    public interface IRepoDepartment
    {
        public List<Department> GetAll();
    }
}
