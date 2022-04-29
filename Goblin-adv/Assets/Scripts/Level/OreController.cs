using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Stats;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OreController : MonoBehaviour,IDamageableObject
{
    private Action<int> _onDeadAction;
    private Hp _hp=new Hp();
    [SerializeField] private TextMeshPro _text;

    private void Start()
    {
        _hp.SetBaseValue(8);
        _hp.SetValue(8);
    }

    public void TakeDamage(float damage)
    {
        _hp.SetValue(_hp.GetValue()-damage);
        Debug.Log(_hp.GetValue());
        _text.text = _hp.GetValue().ToString();
        _text.gameObject.SetActive(true);
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
