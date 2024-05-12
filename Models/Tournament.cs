namespace DiplomMag.models
{

    public class Tournament
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public virtual List<Game> Games { get; set; } = new List<Game> { };
    }
}

