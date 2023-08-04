using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shooling.Models
{
    public class SchoolingActivity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        [Display(Name = "Дата и время начала"),
            DataType(DataType.DateTime),
            Required]
        public DateTime StartTime { get; set; }
        [ForeignKey("UserId"), 
            Display(Name = "Пользователь")]
        public int? UserId { get; set; }
        public UserInfo? User { get; set; }
        [Display(Name = "Достигнутый этап")]
        public string AchievedEtape { get; set; }
        [Display(Name = "Дата и время окончания"),
            DataType(DataType.DateTime),
            Required]
        public DateTime AchievedTime { get; set; }
    }
}
