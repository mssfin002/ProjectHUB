using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Core.Repo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Controllers
{
    public class AOKController : Controller
    {
        private readonly iAOKRepo _aokRepo;
        private readonly SignInManager<ProjectHUBUser> _signinManager;
        private readonly UserManager<ProjectHUBUser> _userManager;
        private readonly iThemeRepo _themeRepo;

        public AOKController(iAOKRepo iAOKRepo, iThemeRepo themeRepo, SignInManager<ProjectHUBUser> signInManager,UserManager<ProjectHUBUser> userManager)
        {
            _aokRepo = iAOKRepo;
            _themeRepo = themeRepo;
            _signinManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? shortTitle)
        {
            if (shortTitle == null)
            {
                return View(_aokRepo.GetAllAOKS());
            }
            else
            {
                return View(_aokRepo.GetAllAOKS().Where(m => m.ThemeShortTitle == shortTitle));
            }
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _aokRepo.GetAllAOKS() == null)
            {
                return NotFound();
            }

            var aOKModel = _aokRepo.GetAllAOKS()
                .FirstOrDefault(m => m.Id == id);
            if (aOKModel == null)
            {
                return NotFound();
            }

            return View(aOKModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortTitle,DateCreated,DateUpdated,StudentCount,ThemeShortTitle,ExpertContact")] AOKModel aOKModel)
        {
            if (ModelState.IsValid)
            {
                aOKModel.Id = Guid.NewGuid();
                aOKModel.User =await _signinManager.UserManager.FindByEmailAsync(User.Identity.Name);
                aOKModel.Theme = _themeRepo.GetThemeByShortTitle(aOKModel.ThemeShortTitle);
                aOKModel.StudentCount = 0;
                aOKModel.DateCreated = DateTime.Now;
                _aokRepo.createAOK(aOKModel);
                var themeShortTitle = aOKModel.ThemeShortTitle;
                return RedirectToAction("Index", "AOK", new {themeShortTitle});
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _aokRepo.GetAllAOKS() == null)
            {
                return NotFound();
            }

            var aOKModel = _aokRepo.GetAokById(id);
            if (aOKModel == null)
            {
                return NotFound();
            }
            return View(aOKModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ShortTitle,DateCreated,DateUpdated,StudentCount,ThemeShortTitle,ExpertContact")] AOKModel aOKModel)
        {
            if (id != aOKModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    aOKModel.DateUpdated = DateTime.Now;
                    _aokRepo.UpdateAOK(aOKModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AOKModelExists(aOKModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", aOKModel.ThemeShortTitle);
            }
            return View(aOKModel);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _aokRepo.GetAllAOKS() == null)
            {
                return NotFound();
            }
            
            var aOKModel = _aokRepo.GetAllAOKS()
                .FirstOrDefault(m => m.Id == id);
            var themeTitle = aOKModel.ThemeShortTitle;
            if (aOKModel == null)
            {
                return NotFound();
            }

            return View(aOKModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_aokRepo.GetAllAOKS() == null)
            {
                return Problem("Entity set 'ProjectHUBContext.AreasOfKnowledge'  is null.");
            }
            var aOKModel = _aokRepo.GetAokById(id);
            var themeTitle = aOKModel.ThemeShortTitle;
            if (aOKModel != null)
            {
                _aokRepo.DeleteAOK(aOKModel);
            }
            
            return RedirectToAction("Index", "AOK", new {themeTitle});
        }

        private bool AOKModelExists(Guid id)
        {
          return _aokRepo.GetAllAOKS().Any(e => e.Id == id);
        }
    }
}
