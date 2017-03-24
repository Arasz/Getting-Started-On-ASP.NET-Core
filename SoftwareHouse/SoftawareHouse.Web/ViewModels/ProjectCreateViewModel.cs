using System.ComponentModel.DataAnnotations;

namespace SoftawareHouse.Web.ViewModels
{
    public class ProjectCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
    }
}