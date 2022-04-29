using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.Timeline;

    public class GroundSlam:ISkill
    {
        public float Timer { set; get; }
        private float _skillCD;
        private float SkillRange;
        private float damage;
        public string CostType { set; get;}
        public float Cost { set; get; }
        public void CastSkill(Transform player,LayerMask layerMask)
        {
            Timer = _skillCD;
                Collider[] enemies = Physics.OverlapSphere(player.position, SkillRange,layerMask);
                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<IDamageableObject>().TakeDamage(damage);
                    }
                }
        
        }

        public GroundSlam()
        {
            _skillCD = 5;
            SkillRange = 1;
            damage = 8;
            Timer = 0;
            Cost = 5;
            CostType = "Rage";
        }

        public float GetSkillCD()
        {
            return _skillCD;
        }
        }
    
