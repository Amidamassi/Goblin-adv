﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class OreController : MonoBehaviour,IDamageableObject
{
    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
    }
}
