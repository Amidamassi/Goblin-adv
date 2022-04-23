namespace DefaultNamespace
{
    public class PlayerStats
    {
        public float speed;
        public float hp;
        public float damage;
        public float attackRadius;
        public float attackCD;
        public int ore;

        public PlayerStats()
        {
            hp = 10;
            speed = 5;
            damage = 1;
            attackRadius = 1;
            attackCD = 1;
            ore = 0;
        }

        public float HpChange(float change)
        {
            hp += change;
            return hp;
        }
    }
}