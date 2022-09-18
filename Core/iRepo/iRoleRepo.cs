using Microsoft.AspNetCore.Identity;

namespace ProjectHUB.Core.iRepo
{
    public interface iRoleRepo
    {
        ICollection<IdentityRole> GetRoles();
    }
}
