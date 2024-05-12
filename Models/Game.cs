using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiplomMag.models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual List<Player> Players { get; set; } = new List<Player> { };
        public Guid TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

    }






}
