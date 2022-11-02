using UnityEngine;
using UnityEngine.Timeline;
    public class ShockWave:Skill
    {
        public float Timer { set; get; }
        private float _skillCD;
        private float SkillRange;
        private float damage;
        public float Cost { set; get; }
        public string CostType { set; get; }
        public float GetSkillCD()
        {
            return _skillCD;
        }
    }
