namespace DiplomMag.models
{
    public class Game
    {
        public Guid Id { get; set; }
        public virtual List<Player> Players { get; set; } = new List<Player> { };
        public Guid TournamentId { get; set; }
        public string GameDate { get; set; }
        public virtual Tournament Tournament { get; set; }

    }
}
