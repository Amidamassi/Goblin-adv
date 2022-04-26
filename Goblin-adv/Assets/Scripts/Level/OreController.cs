using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Stats;
using UnityEngine;

public class OreController : MonoBehaviour,IDamageableObject
{
    private Action<int> _onDeadAction;
    private Hp _hp=new Hp();

    private void Start()
    {
        _hp.SetValue(8);
        _hp.SetBaseValue(8);
    }

    public void TakeDamage(float damage)
    {
        _hp.SetValue(_hp.GetValue()-damage);
        if (_hp.GetValue() <= 0)
        {
            LoseAllHp();
        }
    }

    public void LoseAllHp()
    {
        _onDeadAction.Invoke(1);
        Destroy(gameObject);
    }

    public void InitDeadAction(Action<int>  onDeadAction)
    {
        _onDeadAction = onDeadAction;
    }
}
