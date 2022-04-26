using DefaultNamespace.Stats;

namespace DefaultNamespace
{
    public class PlayerStats
    {
        public Speed speed = new Speed();
        public Hp hp = new Hp();
        public BaseAttackStats BaseAttackStats=new BaseAttackStats();
        public int Ore;

        public PlayerStats()
        {
            hp.SetBaseValue(10);
            hp.SetValue(10);
            speed.SetValue(3);
            BaseAttackStats.SetValue(4);
            BaseAttackStats.AttackRadius = 0.35f;
            BaseAttackStats.AttackCD = 1;
            Ore = 0;
        }

        public float HpChange(float change)
        {
            hp.SetValue(hp.GetValue()+change);
            return hp.GetValue();
        }

        public int OreChange(int change)
        {
            Ore += change;
            return Ore;
        }
    }
}