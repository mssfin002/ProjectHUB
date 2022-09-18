using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectHUB.Areas.Identity.Data;

namespace ProjectHUB.Models.ViewModels
{
    public class EditUserViewModel
    {
        public ProjectHUBUser User { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
