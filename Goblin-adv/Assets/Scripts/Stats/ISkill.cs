
using UnityEngine;

    public interface ISkill
    {
        float Timer { set; get; }
        float Cost { set; get; }
        string CostType { set; get;}
        void CastSkill(Transform player,LayerMask layerMask);
        float GetSkillCD();
    }
