using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace;
using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.Serialization;
public class SkillController:MonoBehaviour
    {
        public void CastSkill(Skill skill,Transform player,LayerMask layerMask)
        {
            skill.Timer = skill._skillCD;
            Collider[] enemies = Physics.OverlapSphere(player.position, skill.SkillRange,layerMask);
            if (enemies.Length != 0)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<IDamageableObject>().TakeDamage(skill.Damage);
                }
            }
        
        }
    }
