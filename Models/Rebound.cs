namespace DiplomMag.models
{

    public class Rebound
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RebOfAlien { get; set; }
        public int RebOfOwn { get; set; }
        public int AllReb { get { return RebOfAlien + RebOfOwn; } set { AllReb = value; } }

        public Guid StatisticId { get; set; }
        public virtual Statistic Statistic { get; set; }

    }
}
