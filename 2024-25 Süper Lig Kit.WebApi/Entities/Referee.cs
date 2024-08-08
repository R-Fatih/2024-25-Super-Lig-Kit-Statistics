namespace _2024_25_Süper_Lig_Kit.WebApi.Entities
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public bool IsFifa { get; set; }
        public string ImgUrl { get; set; }
        public List<Match> Match { get; set; }
    }
}
