using UnityEngine;

namespace DefaultNamespace.Stats
{
    public class Hp:BaseStats
    {
        private float _maxHP;
        public new StatsEnum statType = StatsEnum.Hp;
        public void SetValue(float value)
        {
            Value = value;
            if (Value > _maxHP*Modificator)
            {
                Value = _maxHP*Modificator;
            }
        }

        public float GetValue()
        {
            return Value;
        }

        public void SetMaxValue(float value)
        {
            _maxHP = value;
        }
        public float GetMaxValue()
        {
            return _maxHP;
        }
    }
}