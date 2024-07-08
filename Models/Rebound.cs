namespace DiplomMag.models
{

    public class Rebound
    {
        public Guid Id { get; set; }
        public int RebOfAlien { get; set; }
        public int RebOfOwn { get; set; }
        public int AllReb { get; set; }
        public int _AllReb { get { return AllReb; } set { this.AllReb = RebOfAlien + RebOfOwn; } }

        public Guid StatisticId { get; set; }
        public virtual Statistic? Statistic { get; set; }

    }
}
