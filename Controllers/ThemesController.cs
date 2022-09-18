using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Controllers
{
    [Authorize(Roles ="Expert")]
    public class ThemesController : Controller
    {
        private readonly iThemeRepo _themeRepo;

        public ThemesController(iThemeRepo themeRepo)
        {
            _themeRepo = themeRepo;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return View(_themeRepo.GetThemes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortTitle")] ThemeModel themeModel)
        {

            if (ModelState.IsValid)
            {
                themeModel.Id = Guid.NewGuid();
                _themeRepo.CreateTheme(themeModel);
                return RedirectToAction(nameof(Index));
            }
            return View(themeModel);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _themeRepo.GetThemes() == null)
            {
                return NotFound();
            }

            var themeModel = _themeRepo.GetThemeById(id);
            if (themeModel == null)
            {
                return NotFound();
            }
            return View(themeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ShortTitle")] ThemeModel themeModel)
        {
            if (id != themeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _themeRepo.UpdateTheme(themeModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThemeModelExists(themeModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(themeModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _themeRepo.GetThemes() == null)
            {
                return NotFound();
            }

            var themeModel = _themeRepo.GetThemes()
                .FirstOrDefault(m => m.Id == id);
            if (themeModel == null)
            {
                return NotFound();
            }

            return View(themeModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_themeRepo.GetThemes() == null)
            {
                return Problem("Entity set 'ProjectHUBContext.Themes'  is null.");
            }
            var themeModel = _themeRepo.GetThemeById(id);
            if (themeModel != null)
            {
                _themeRepo.DeleteTheme(themeModel);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ThemeModelExists(Guid id)
        {
          return _themeRepo.GetThemes().Any(e => e.Id == id);
        }
    }
}
