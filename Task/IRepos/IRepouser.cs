using Task.Models;

namespace Task.IRepos
{
    public interface IRepouser
    {
        public List<User> GetAll();
    }
}
