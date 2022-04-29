namespace DefaultNamespace.Stats
{
    public class BaseAttackStats:BaseStats
    {
        public new StatsEnum statType = StatsEnum.BaseAttackStats;
        public float AttackRadius { set; get; }
        public float AttackCD { set; get; }
    }
}