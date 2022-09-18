using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Data;
using ProjectHUB.Models;

namespace ProjectHUB.Controllers
{
    public class TopicsController : Controller
    {
        private readonly SignInManager<ProjectHUBUser> _signinManager;
        private readonly UserManager<ProjectHUBUser> _userManager;
        private readonly iAOKRepo _aokRepo;
        private readonly iTopicRepo _topicRepo;

        public TopicsController(SignInManager<ProjectHUBUser> signInManager, UserManager<ProjectHUBUser> userManager, iAOKRepo iAOKRepo, iTopicRepo iTopicRepo)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _aokRepo = iAOKRepo;
            _topicRepo = iTopicRepo;
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            if (id == null)
            {
                return View(_topicRepo.GetTopics());
            }
            else
            {
                return View(_topicRepo.GetTopics().Where(m => m.AreaOfKnowledge.Id == id).ToList());
            }

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _topicRepo.GetTopics() == null)
            {
                return NotFound();
            }

            var topicModel = _topicRepo.GetTopics()
                .FirstOrDefault(m => m.Id == id);
            if (topicModel == null)
            {
                return NotFound();
            }

            return View(topicModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortTitle,Description,Approved,SurnamesOfStaffWorkingOnThis,ExternalCollaborators,FundingDetails,RepresentativeResearchOutput,isChosen,DateCreated,DateUpdated,aokShortTitle,StudentContact,MentorContact")] TopicModel topicModel)
        {
            if (ModelState.IsValid)
            {
                topicModel.Id = Guid.NewGuid();
                topicModel.Mentor = await _signinManager.UserManager.FindByEmailAsync(User.Identity.Name);
                topicModel.AreaOfKnowledge = _aokRepo.GetAOkByShortTitle(topicModel.aokShortTitle);
                topicModel.DateCreated = DateTime.Now;
                _topicRepo.CreateTopic(topicModel);
                return RedirectToAction(nameof(Index));
            }
            var topic = topicModel;
            return View(topicModel);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _topicRepo.GetTopics() == null)
            {
                return NotFound();
            }

            var topicModel = _topicRepo.FindTopicById(id);
            if (topicModel == null)
            {
                return NotFound();
            }
            return View(topicModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ShortTitle,Description,Approved,SurnamesOfStaffWorkingOnThis,ExternalCollaborators,FundingDetails,RepresentativeResearchOutput,isChosen,DateCreated,DateUpdated,aokShortTitle,StudentContact,MentorContact")] TopicModel topicModel)
        {
            if (id != topicModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    topicModel.DateUpdated = DateTime.Now;
                    _topicRepo.UpdateTopic(topicModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicModelExists(topicModel.Id))
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
            return View(topicModel);
        }

        #region select topics
        public async Task<IActionResult> Select(Guid? id)
        {
            if (id == null || _topicRepo.GetTopics() == null)
            {
                return NotFound();
            }

            var topicModel = _topicRepo.GetTopics()
                .FirstOrDefault(m => m.Id == id);
            if (topicModel == null)
            {

                return NotFound();
            }

            return View(topicModel);
        }

        public async Task<IActionResult> Unselect(Guid? id)
        {
            if (id == null || _topicRepo.GetTopics() == null)
            {
                return NotFound();
            }

            var topicModel = _topicRepo.GetTopics()
                .FirstOrDefault(m => m.Id == id);
            if (topicModel == null)
            {

                return NotFound();
            }

            return View(topicModel);
        }

        [HttpPost, ActionName("Unselect")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnselectConfirmed(Guid id)
        {
            if (_topicRepo.GetTopics() == null)
            {
                return Problem("Entity set 'ProjectHUBContext.Topics'  is null.");
            }
            var topicModel = _topicRepo.FindTopicById(id);
            if (topicModel != null)
            {
                topicModel.DateUpdated = DateTime.Now;
                topicModel.StudentContact = null;
                topicModel.AssignedUser = null;
                topicModel.isChosen = false;
                _topicRepo.UpdateTopic(topicModel);
            }
            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Select")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectConfirmed(Guid id)
        {
            if (_topicRepo.GetTopics() == null)
            {
                return Problem("Entity set 'ProjectHUBContext.Topics'  is null.");
            }
            var topicModel = _topicRepo.FindTopicById(id);
            if (topicModel != null)
            {
                topicModel.DateUpdated = DateTime.Now;
                topicModel.StudentContact = User.Identity.Name;
                topicModel.AssignedUser = await _signinManager.UserManager.FindByEmailAsync(User.Identity.Name);
                topicModel.isChosen = true;
                _topicRepo.UpdateTopic(topicModel);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _topicRepo.GetTopics() == null)
            {
                return NotFound();
            }

            var topicModel = _topicRepo.GetTopics()
                .FirstOrDefault(m => m.Id == id);
            if (topicModel == null)
            {
                return NotFound();
            }

            return View(topicModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_topicRepo.GetTopics() == null)
            {
                return Problem("Entity set 'ProjectHUBContext.Topics'  is null.");
            }
            var topicModel = _topicRepo.FindTopicById(id);
            if (topicModel != null)
            {
                _topicRepo.DeleteTopic(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool TopicModelExists(Guid id)
        {
          return _topicRepo.GetTopics().Any(e => e.Id == id);
        }
    }
}
