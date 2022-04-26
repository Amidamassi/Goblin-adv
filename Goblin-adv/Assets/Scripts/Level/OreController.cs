using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class OreController : MonoBehaviour,IDamageableObject
{
    private Action<int> _onDeadAction;
    public void TakeDamage(float damage)
    {
        _onDeadAction.Invoke(1);
        Destroy(gameObject);
    }

    public void LoseAllHp()
    {
        
    }

    public void InitDeadAction(Action<int>  onDeadAction)
    {
        _onDeadAction = onDeadAction;
    }
}
