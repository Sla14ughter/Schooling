using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Shooling.Models
{
    public class SchoolingActivityViewModel
    {
        public SchoolingActivity Activity { get; set; }
        public SelectList? Users { get; set; }
        [Required(ErrorMessage = "Выберите пользователя."),
            Display(Name = "Пользователь")]
        public int SelectedUserId { get; set; }
    }
}
