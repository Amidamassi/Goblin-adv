using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace;
using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IDamageableObject
{
    private Vector3 _playermovement;
    public PlayerStats _playerStats;
    [SerializeField] public UiController uiController;
    private CraftController _craftController;

    [SerializeField] private SkillController _skillController;
    [FormerlySerializedAs("_house")] [SerializeField]
    private Transform house;

    [SerializeField] private LayerMask _damageableLayerMask;
    [SerializeField] private LayerMask _interactiveLayerMask;
    private float _timer;
    [SerializeField] public PassivesController passivesController;

    private Action<Transform> _startCraftAction;
    private Action _stopCraftAction;

    public void Initialize()
    {
        _playerStats = new PlayerStats();
        uiController.VisualHpChange(_playerStats.HpChange(0),_playerStats.hp.GetMaxValue());
        uiController.VisualOreChange(_playerStats.OreChange(0));
        uiController.VisualRageChange(_playerStats.rage.GetValue(),_playerStats.rage.GetMaxValue());
        _craftController = new CraftController();
        _playerStats.Skill1 = new GroundSlam();
        _playerStats.Skill2 = new ShockWave();
    }

    private void FixedUpdate()
    {
        uiController.UpdatePlayerVisual(_playerStats.hp,_playerStats.rage,_playerStats.Ore);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playermovement.z = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _playermovement.z = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playermovement.x = +1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playermovement.x = -1;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (TryCastSkill(_playerStats.Skill1))
            {
                uiController.CastSkill1(_playerStats.Skill1._skillCD);
                _skillController.CastSkill(_playerStats.Skill1,this.transform, _damageableLayerMask);
                PaySkillCost(_playerStats.Skill1);
            }

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (TryCastSkill(_playerStats.Skill2))
            {
                uiController.CastSkill2(_playerStats.Skill2._skillCD);
                _skillController.CastSkill(_playerStats.Skill2,this.transform, _damageableLayerMask);
                PaySkillCost(_playerStats.Skill2);
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            Collider[] obj = Physics.OverlapSphere(transform.position, 1, _interactiveLayerMask);
            if (obj.Length != 0)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].GetComponent<IInteractive>().Action();
                }
            }
        }

        transform.Translate(_playerStats.speed.GetValue() * Time.deltaTime * _playermovement.normalized);

        _playermovement = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _startCraftAction.Invoke(_craftController.Craft(house, transform));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _stopCraftAction.Invoke();
        }

        _playerStats.Skill1.Timer -= Time.deltaTime;
        _playerStats.Skill2.Timer -= Time.deltaTime;
        _timer -= Time.deltaTime;
        if (_playerStats.hp.GetValue() <= 0)
        {
            uiController.OpenLoseWindow();
        }
    }

    public void TakeDamage(float damage)
    {
        _playerStats.HpChange(-damage);
    }

    public void LoseAllHp()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("win");
        }
    }

    public void DealAttack(Vector3 attackCenter)
    {
        if (_timer <= 0)
        {
            _timer = _playerStats.BaseAttackStats.AttackCD;
            uiController.DealAttack(_playerStats.BaseAttackStats.AttackCD);
            Collider[] enemies = Physics.OverlapSphere(attackCenter, _playerStats.BaseAttackStats.AttackRadius,
                _damageableLayerMask);
            if (enemies.Length != 0)
            {
                _playerStats.rage.SetValue(_playerStats.rage.GetValue() + 1);
                uiController.VisualRageChange(_playerStats.rage.GetValue(),_playerStats.rage.GetMaxValue());
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<IDamageableObject>().TakeDamage(_playerStats.BaseAttackStats.GetValue());
                }


            }

        }
    }

    public void OreChange(int change)
    {
        _playerStats.OreChange(change);

    }

    public void UpgradeAttack()
    {
        _playerStats.BaseAttackStats.SetValue(_playerStats.BaseAttackStats.GetValue() + 1);
    }

    public void UpgradeSpeed()
    {
        _playerStats.speed.SetValue(_playerStats.speed.GetValue() + 1);
    }

    public void Heal()
    {
        _playerStats.HpChange(3);
    }
    

    private bool TryCastSkill(Skill skill)
    {
        if ((skill.Timer <= 0)&(CheckSkillCost(skill)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckSkillCost(Skill skill)
    {
        switch (skill.CostType)
        {
            case "Rage": return skill.Cost <= _playerStats.rage.GetValue();
            
        }

        return false;
    }

    private void PaySkillCost(Skill skill)
    {
        switch (skill.CostType)
        {
            case "Rage":
                _playerStats.rage.SetValue(_playerStats.rage.GetValue() - skill.Cost);
                _playerStats.rage.GetValue();

                break;
        }
    }

    public void AddPassive(Passives passive)
    {
        passivesController.AddPassive(_playerStats, passive);
    }
    
    public void StartCraft(Action<Transform> action)
    {
        _startCraftAction = action;
    }
    public void StopCraft(Action action)
    {
        _stopCraftAction = action;
    }

}
