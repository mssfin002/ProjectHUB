using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectHUB.Models
{
    public class ThemeModel
    {
        #region class attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(455), Display(Name = "Short Title")]
        public string ShortTitle { get; set; }
        #endregion

        #region navigational attributes
        public virtual ICollection<AOKModel> AreasOfKnowledge { get; set; }
        #endregion

    }
}
