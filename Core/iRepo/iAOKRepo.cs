using ProjectHUB.Models;

namespace ProjectHUB.Core.iRepo
{
    public interface iAOKRepo
    {
        ICollection<AOKModel> GetAllAOKS();

        ICollection<ThemeModel> GetAllThemes();

        ThemeModel GetThemeById(Guid id);

        AOKModel GetAOkByShortTitle(string shortTitle);

        AOKModel GetAokById(Guid id);

        void createAOK(AOKModel aokModel);
        void DeleteAOK(AOKModel aokModel);
        void UpdateAOK(AOKModel aokModel);

        
    }
}
