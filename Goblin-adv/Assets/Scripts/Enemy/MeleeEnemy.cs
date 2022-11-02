using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
    public class MeleeEnemy:Enemy
    {
        public MeleeEnemy()
        {
        hp.SetMaxValue(10);
        hp.SetValue(10);
        baseAttackStats.SetValue(1);
        baseAttackStats.AttackRadius = 1.5f;
        baseAttackStats.AttackCD = 1;
        reward = 10f;
        }
    }
