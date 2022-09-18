using ProjectHUB.Areas.Identity.Data;

namespace ProjectHUB.Core.iRepo
{
    public interface iUserRepo
    {
        ICollection<ProjectHUBUser> GetUsers();
        ProjectHUBUser GetUser(string id);
        ProjectHUBUser UpdateUser(ProjectHUBUser User);
    }
}
