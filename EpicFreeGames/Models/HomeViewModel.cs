namespace EpicFreeGames.Models
{
    public class HomeViewModel
    {
        public IReadOnlyList<FreeGame> FreeGames { get; set; } = [];
    }

    public class FreeGame
    {
        public string ImageUrl { get; set; } = "";
        public string ImageBase64 { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}