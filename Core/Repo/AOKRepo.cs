using Microsoft.EntityFrameworkCore;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Core.Repo
{
    public class AOKRepo : iAOKRepo
    {
        private readonly ProjectHUBContext _context;

        public AOKRepo(ProjectHUBContext context)
        {
            _context = context; 
        }
        public void createAOK(AOKModel aokModel)
        {
            _context.AreasOfKnowledge.Add(aokModel);
            _context.SaveChanges();
        }

        public void DeleteAOK(AOKModel aokModel)
        {
            _context.AreasOfKnowledge.Remove(aokModel);
            _context.SaveChanges();
        }

        public ICollection<AOKModel> GetAllAOKS()
        {
            return _context.AreasOfKnowledge
                .Include(m => m.Theme)
                .Include(m => m.Topics).ToList();
        }

        public ICollection<ThemeModel> GetAllThemes()
        {
            return _context.Themes.ToList();
        }

        public AOKModel GetAokById(Guid id)
        {
            return _context.AreasOfKnowledge.FirstOrDefault(m => m.Id == id);
        }

        public AOKModel GetAOkByShortTitle(string shortTitle)
        {
            return _context.AreasOfKnowledge.FirstOrDefault(m => m.ShortTitle == shortTitle);
        }

        public ThemeModel GetThemeById(Guid id)
        {
            return _context.Themes.First(m => m.Id == id);
        }

        public void UpdateAOK(AOKModel aokModel)
        {
            _context.AreasOfKnowledge.Update(aokModel);
            _context.SaveChanges();
        }
    }
}
