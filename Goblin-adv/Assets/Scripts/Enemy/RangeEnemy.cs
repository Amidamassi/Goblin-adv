
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

    public class RangeEnemy:Enemy

    {
        
        public RangeEnemy()
        { 
        hp.SetBaseValue(10); 
        hp.SetValue(10);
        baseAttackStats.SetValue(1);
        baseAttackStats.AttackRadius = 3;
        baseAttackStats.AttackCD = 2;
        projectileSpeed = 5;
        reward = 10f;
        }
        
    }
