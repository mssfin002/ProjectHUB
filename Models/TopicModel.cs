using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ProjectHUB.Areas.Identity.Data;

namespace ProjectHUB.Models
{
    public class TopicModel
    {
        #region class attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(455), Display(Name = "Short Title")]
        public string ShortTitle { get; set; }

        [Required]
        [StringLength(455), Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Staff Collaboring (Surnames)")]
        public string? SurnamesOfStaffWorkingOnThis { get; set; }
        [Display(Name = "External Collaborators")]
        public string? ExternalCollaborators { get; set; }

        [Display(Name = "(Funder) Bank Branch")]
        public string? FundingDetails { get; set; }

        [Display(Name = "Representative Research Ouput")]
        public string? RepresentativeResearchOutput { get; set; }

        [Required, Display(Name = "Is Chosen?")]
        public bool isChosen { get; set; } = false;

        [Required, Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; } = false;
        #endregion

        #region navigational attributes
        [Display(Name = "Area of Knowledge")]
        public virtual AOKModel AreaOfKnowledge { get; set; }
        [Required,Display(Name ="AOK")]
        public string aokShortTitle { get; set; }

        [Display(Name = "Post-Grad Student Assigned")]
        public virtual ProjectHUBUser? AssignedUser { get; set; }

        [Display(Name = "Student Contact")]
        public string? StudentContact { get; set; }

        public virtual ProjectHUBUser Mentor { get; set; }

        [Display(Name = "Mentor Contact")]
        public string MentorContact { get; set; }
        #endregion

    }
}
