namespace DefaultNamespace
{
    public class GoblinStats
    {
        public float speed;
        public float hp;

        public GoblinStats()
        {
            hp = 10;
            speed = 5;
        }

        public float HpChange(float change)
        {
            hp += change;
            return hp;
        }
    }
}