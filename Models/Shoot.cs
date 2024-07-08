namespace DiplomMag.models
{

    public class Shoot
    {
        public Guid Id { get; set; }
        public int TwoPointScoredPoints { get; set; }
        public int TwoPointAllPoints { get; set; }
        public int ThreePointScoredPoints { get; set; }
        public int ThreePointAllPoints { get; set; }
        public int FreeThrowsScoredPoints { get; set; }
        public int FreeThrowsAllPoints { get; set; }
        public int FieldGoalsAllPoints { get; set; }
        public int _FieldGoalsAllPoints { get { return FieldGoalsAllPoints; } set { this.FieldGoalsAllPoints = ThreePointAllPoints + TwoPointAllPoints; ; } }
        public int FieldGoalsScoredPoints { get; set; }
		public int _FieldGoalsScoredPoints { get { return FieldGoalsScoredPoints; } set { this.FieldGoalsScoredPoints = ThreePointScoredPoints + TwoPointScoredPoints; ; } }

        public Guid StatisticId { get; set; }
        public virtual Statistic? Statistic { get; set; }

    }
}



