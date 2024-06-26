﻿namespace DiplomMag.models
{

    public class Shoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int TwoPointScoredPoints { get; set; }
        public int TwoPointAllPoints { get; set; }
        public int ThreePointScoredPoints { get; set; }
        public int ThreePointAllPoints { get; set; }
        public int FreeThrowsScoredPoints { get; set; }
        public int FreeThrowsAllPoints { get; set; }
        public int FieldGoalsAllPoints { get { return ThreePointAllPoints + TwoPointAllPoints; } set { FieldGoalsAllPoints = value; } }
        public int FieldGoalsScoredPoints { get { return ThreePointScoredPoints + TwoPointScoredPoints; } set { FieldGoalsScoredPoints = value; } }

        public Guid StatisticId { get; set; }
        public virtual Statistic Statistic { get; set; }

    }
}



