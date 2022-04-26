namespace DefaultNamespace.Stats
{
    public class BaseStats
    {
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
}