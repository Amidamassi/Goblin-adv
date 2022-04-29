using System;

    public class BaseStats
    {
        protected StatsEnum statType;
        protected float Value;
        protected float Modificator = 1;

        public float GetValue()
        {
            return Value*Modificator;
        }

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetModificatorValue(float change)
        {
            Modificator += change;
        }
    }

    public enum StatsEnum
    {
        Hp=1,
        Speed=2,
        BaseAttackStats=3,
        Rage=4
    }
