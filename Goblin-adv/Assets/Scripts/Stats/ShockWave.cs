using UnityEngine;
using UnityEngine.Timeline;
    public class ShockWave:ISkill
    {
        public float Timer { set; get; }
        private float _skillCD;
        private float SkillRange;
        private float damage;
        public float Cost { set; get; }
        public string CostType { set; get; }
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
        public float GetSkillCD()
        {
            return _skillCD;
        }
    }
