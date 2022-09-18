using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Core.Repo
{
    public class ThemeRepo : iThemeRepo
    {
        private readonly ProjectHUBContext _context;

        public ThemeRepo(ProjectHUBContext context)
        {
            _context = context;
        }
        public void CreateTheme(ThemeModel theme)
        {
            _context.Themes.Add(theme);
            _context.SaveChanges();
        }

        public void DeleteTheme(ThemeModel theme)
        {
            _context.Themes.Remove(theme);
            _context.SaveChanges();
        }

        public ThemeModel GetThemeById(Guid id)
        {
           return _context.Themes.FirstOrDefault(x => x.Id == id);
        }

        public ThemeModel GetThemeByShortTitle(string shortTitle)
        {
            return _context.Themes.Where(m => m.ShortTitle == shortTitle).FirstOrDefault();
        }

        public Guid GetThemeIdFromTitle(string title)
        {
            ThemeModel theme = _context.Themes.FirstOrDefault(m => m.ShortTitle == title);
            return theme.Id;
        }

        public ICollection<ThemeModel> GetThemes()
        {
            return _context.Themes
                .Include(x => x.AreasOfKnowledge).ToList();
        }

        public void UpdateAOKs(ThemeModel theme, AOKModel aOKModel)
        {
            theme.AreasOfKnowledge.Add(aOKModel);
            _context.Themes.Update(theme);
            _context.SaveChanges();
        }

        public ThemeModel UpdateTheme(ThemeModel theme)
        {
            _context.Themes.Update(theme);
            _context.SaveChanges();

            return theme;
        }
    }
}
