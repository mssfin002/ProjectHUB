using ProjectHUB.Models;

namespace ProjectHUB.Core.iRepo
{
    public interface iThemeRepo
    {
        ICollection<ThemeModel> GetThemes();
        ThemeModel GetThemeByShortTitle(string shortTitle);
        ThemeModel GetThemeById(Guid id);
        ThemeModel UpdateTheme(ThemeModel theme);

        Guid GetThemeIdFromTitle(string title);
        void CreateTheme(ThemeModel theme);
        void DeleteTheme(ThemeModel theme);

        void UpdateAOKs(ThemeModel theme, AOKModel aOKModel);
    }
}
