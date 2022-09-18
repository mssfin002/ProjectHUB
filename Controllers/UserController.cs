using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Models.ViewModels;
using System.Data;
using System.Web;

namespace ProjectHUB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly iUnitofWork _unitofWork;
        private readonly SignInManager<ProjectHUBUser> _signInManager;

        public UserController(iUnitofWork unitofWork, SignInManager<ProjectHUBUser> signInManager)
        {
            _unitofWork = unitofWork;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Details(string? id)
        {
            throw new Exception();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = _unitofWork.User.GetUser(id);
            var roles = _unitofWork.Role.GetRoles();
            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);


            var roleItems = roles.Select(role =>
            new SelectListItem(role.Name, role.Id, userRoles.Any(ur => ur.Contains(role.Name)))).ToList();

            var userVM = new EditUserViewModel
            {
                User = user,
                Roles = roleItems

            };

            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            var user = _unitofWork.User.GetUser(data.User.Id);

            if (user == null)
            {
                return NotFound();
            }

            var DBuserRoles = await _signInManager.UserManager.GetRolesAsync(user);
            var rolesToAdd = new List<string>();
            var rolestoDel = new List<string>();

            foreach (var role in data.Roles)
            {
                var assignedinDB = DBuserRoles.FirstOrDefault(ur => ur == role.Text);

                if (role.Selected)
                {
                    if (assignedinDB == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedinDB != null)
                    {
                        rolestoDel.Add(role.Text);
                    }
                }
            }
            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolestoDel.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolestoDel);
            }

            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.StudentNumber = data.User.StudentNumber;
            user.Email = data.User.Email;

            _unitofWork.User.UpdateUser(user);

            return RedirectToAction("ListUsers");


        }

        public ViewResult ListUsers(string searchString)
        {

            var users = _unitofWork.User.GetUsers();
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString)).ToList();
            }   



            return View(users);
        }


        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _unitofWork.User.GetUsers();
            return View(users);
        }

    }
}
