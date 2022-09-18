using ProjectHUB.Core.iRepo;

namespace ProjectHUB.Core.Repo
{
    public class UnitOfWork : iUnitofWork
    {
        public iUserRepo User { get ; set ; }
        public iRoleRepo Role { get ; set ; }

        public UnitOfWork(iUserRepo iUserRepo, iRoleRepo iRoleRepo)
        {
            User = iUserRepo;
            Role = iRoleRepo;
        }
    }
}
