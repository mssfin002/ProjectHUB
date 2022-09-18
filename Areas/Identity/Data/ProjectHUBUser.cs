using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace ProjectHUB.Areas.Identity.Data;

public class ProjectHUBUser : IdentityUser
{
    #region class attributes
    [Required, StringLength(9, MinimumLength = 9, ErrorMessage = "Your student number should be 9 digits in length")]
    [Display(Name = "Student Number")]
    public string StudentNumber { get; set; }

    [Required, StringLength(455)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required, StringLength(455)]
    [Display(Name = "Last Name")]
    [ScaffoldColumn(true)]
    public string LastName { get; set; }

    [Required, Display(Name = "Date Created")]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Required, Display(Name = "Last Updated")]
    public DateTime LastUpdated { get; set; }
    #endregion


}

public class ProjectHUBuserRole : IdentityRole
{

}

