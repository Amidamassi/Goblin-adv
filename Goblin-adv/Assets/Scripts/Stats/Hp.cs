using UnityEngine;

namespace DefaultNamespace.Stats
{
    public class Hp:BaseStats
    {
        private float _baseHP;
        public void SetValue(float value)
        {
            Value = value;
            if (Value > _baseHP*Modificator)
            {
                Value = _baseHP*Modificator;
            }
        }

        public float GetValue()
        {
            return Value;
        }

        public void SetBaseValue(float value)
        {
            _baseHP = value;
        }
    }
}