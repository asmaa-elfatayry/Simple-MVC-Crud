using Microsoft.EntityFrameworkCore;
using Task.IRepos;
using Task.Models;

namespace Task.Repos
{


    public class RepoUser : IRepouser
    {
        private readonly EmpTaskContext _context;
        public RepoUser(EmpTaskContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        
        }
    }
}
