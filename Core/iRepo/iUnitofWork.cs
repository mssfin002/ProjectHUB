namespace ProjectHUB.Core.iRepo
{
    public interface iUnitofWork
    {
        iUserRepo User { get; set; }
        iRoleRepo Role { get; set; }
    }
}
