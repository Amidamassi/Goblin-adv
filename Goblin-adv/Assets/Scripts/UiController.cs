using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image _hp;
    [SerializeField] private Text _ore;
    [SerializeField] private Image _attackImage;
    [SerializeField] private Image _skill1Image;
    [SerializeField] private Image _skill2Image;
    [SerializeField] private TraderWindowController _traderWindow;
    [SerializeField] private Image _rage;

    [SerializeField] private GameObject LoseWindow;
    private float _attackTimer;
    private float _skill1Timer;
    private float _skill2Timer;
    

    public void VisualHpChange(float newHp,float newMaxHp)
    {
        _hp.fillAmount = newHp/newMaxHp;
    }

    public void VisualOreChange(float newOre)
    {
        _ore.text = newOre.ToString();
    }
    public void VisualRageChange(float newRage,float newMaxRage)
    {
        _rage.fillAmount = newRage/newMaxRage;
    }

    public void DealAttack(float timer)
    {
        _attackTimer = timer;
        _attackImage.fillAmount = 0;
    }
    
    public void CastSkill1(float timer)
    {
        _skill1Timer = timer;
        _skill1Image.fillAmount = 0;
    }
    
    public void CastSkill2(float timer)
    {
        _skill2Timer = timer;
        _skill2Image.fillAmount = 0;
    }

    private void Update()
    {
        if (_attackImage.fillAmount < 1)
        {
            _attackImage.fillAmount += Time.deltaTime / _attackTimer;
        }
        if (_skill1Image.fillAmount < 1)
        {
            _skill1Image.fillAmount += Time.deltaTime / _skill1Timer;
        }
        if (_skill2Image.fillAmount < 1)
        {
            _skill2Image.fillAmount += Time.deltaTime / _skill2Timer;
        }
    }

    public void OpenTraderWindow(Passives[] passives)
    {
        _traderWindow.gameObject.SetActive(true);
        _traderWindow.initialization(passives);
    }

    public void OpenLoseWindow()
    {
        LoseWindow.SetActive(true);
    }

    public void AddPassiveTraderWindow(Action<Passives> action)
    {
        _traderWindow.AddPassive(action);
    }

    public void UpdatePlayerVisual(Hp hp,Rage rage,float ore)
    {
        VisualHpChange(hp.GetValue(),hp.GetMaxValue());
        VisualRageChange(rage.GetValue(),rage.GetMaxValue());
        VisualOreChange(ore);
        
    }
}
