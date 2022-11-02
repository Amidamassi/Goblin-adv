namespace DefaultNamespace.Stats
{
    public class Rage:BaseStats
    {
        public new StatsEnum statType = StatsEnum.Rage;
        private float _maxRage;
        public void SetValue(float value)
        {
            Value = value;
            if (Value > _maxRage*Modificator)
            {
                Value = _maxRage*Modificator;
            }
        }

        public float GetValue()
        {
            return Value;
        }

        public void SetMaxValue(float value)
        {
            _maxRage = value;
        }
        public float GetMaxValue()
        {
            return _maxRage;
        }
    }
}