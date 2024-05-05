using Task.Models;

namespace Task.IRepos
{
    public interface IRepoEmployee
    {
        public List<Employee> GetAll();

        public void Save();
        public void Add(Employee employee);

        public void Delete(int id);

        public Employee GetById(int id);

        public void Update(Employee employee);
    }
}
