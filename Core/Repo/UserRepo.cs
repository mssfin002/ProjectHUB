using Microsoft.EntityFrameworkCore;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;

namespace ProjectHUB.Core.Repo
{
    public class UserRepo : iUserRepo
    {
        private readonly ProjectHUBContext _context;

        public UserRepo(ProjectHUBContext context)
        {
            _context = context;
        }
        public ProjectHUBUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<ProjectHUBUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ProjectHUBUser UpdateUser(ProjectHUBUser User)
        {
            _context.Update(User);
            _context.SaveChanges();
            return User;
        }
    }
}
