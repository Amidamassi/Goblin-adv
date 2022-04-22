namespace DefaultNamespace
{
    public class PlayerStats
    {
        public float speed;
        public float hp;

        public PlayerStats()
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