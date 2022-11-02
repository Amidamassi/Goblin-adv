using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.Timeline;

    public class GroundSlam:Skill
    {
     
        public GroundSlam()
        {
            _skillCD = 5;
            SkillRange = 1;
            Damage = 8;
            Timer = 0;
            Cost = 5;
            CostType = "Rage";
        }

        public float GetSkillCD()
        {
            return _skillCD;
        }
        }
    
