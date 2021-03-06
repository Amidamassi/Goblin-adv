using System.Collections.Generic;
using DefaultNamespace.Stats;

namespace DefaultNamespace
{
    public class PlayerStats
    {
        public Speed speed = new Speed();
        public Hp hp = new Hp();
        public BaseAttackStats BaseAttackStats=new BaseAttackStats();
        public int Ore;
        public Rage rage = new Rage();
        public ISkill Skill1;
        public ISkill Skill2;
        public List<BaseStats> Stats=new List<BaseStats>();

        public PlayerStats()
        {
            hp.SetBaseValue(10);
            hp.SetValue(10);
            speed.SetValue(3);
            BaseAttackStats.SetValue(2);
            BaseAttackStats.AttackRadius = 0.35f;
            BaseAttackStats.AttackCD = 0.5f;
            Ore = 0;
            Stats.Add(hp);
            Stats.Add(speed);
            Stats.Add(BaseAttackStats);
            Stats.Add(rage);
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