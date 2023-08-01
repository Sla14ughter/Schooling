namespace Shooling.Models
{
    public class ShoolingActivity
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public UserInfo User { get; set; }
        public string AchievedEtape { get; set; }
        public DateTime AchievedTime { get; set; }
    }
}
