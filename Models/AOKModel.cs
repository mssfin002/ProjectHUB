using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectHUB.Areas.Identity.Data;

namespace ProjectHUB.Models
{
    public class AOKModel
    {
        #region class methods
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(455), Display(Name = "Short Title")]
        public string ShortTitle { get; set; }

        [Required, Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }

        public int StudentCount { get; set; } = 0;
        #endregion

        #region navigational attributes 
        [Display(Name = "Theme")]
        public virtual ThemeModel Theme { get; set; }

        [Display(Name = "Theme Short Title")]
        public string ThemeShortTitle { get; set;}

        [Display(Name = "Expert")]
        public virtual ProjectHUBUser User { get; set; }

        [Display(Name = "Expert Contact")]
        public string ExpertContact { get; set; }

        public virtual ICollection<TopicModel> Topics { get; set; }
        #endregion

    }
}
