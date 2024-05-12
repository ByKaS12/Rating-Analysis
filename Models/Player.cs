using DiplomMag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomMag.models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Weight { get; set; }
        public double Height {  get; set; } 
        public string PlayerPosition { get; set; }
        public virtual Statistic Statistic { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }

    }
}
