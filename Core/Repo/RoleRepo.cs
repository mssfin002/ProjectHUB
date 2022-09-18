using Microsoft.AspNetCore.Identity;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;

namespace ProjectHUB.Core.Repo
{
    public class RoleRepo : iRoleRepo
    {
        private ProjectHUBContext _context;

        public RoleRepo(ProjectHUBContext CONTEXT)
        {
            _context = CONTEXT; 
        }
        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
