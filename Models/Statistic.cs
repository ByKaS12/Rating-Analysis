﻿namespace DiplomMag.models
{
    public class Statistic
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public TimeOnly TimePlayed { get; set; }
        public virtual required Shoot Shoots { get; set; }
        public int Points { get { return ((Shoots.ThreePointScoredPoints * 3) + (Shoots.TwoPointScoredPoints * 2) + Shoots.FreeThrowsScoredPoints); } set { Points = value; } }

        public virtual required Rebound Rebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Losses { get; set; }
        public int Blockshots { get; set; }
        public int Fouls { get; set; }
        public int FoulsOfEnemy { get; set; }
        public int PlusMinus { get; set; }
        public int KPI { get; set; }
        public double CalcHollinger { get; set; }

        public Guid PlayerId { get; set; }
        public virtual required Player Player { get; set; }

    }
}