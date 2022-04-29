using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace;
using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IDamageableObject
{
    private Vector3 _playermovement;
    public PlayerStats _playerStats;
    [SerializeField] public UiController uiController;
    private CraftController _craftController;
    [SerializeField] private MouseController mouseController;

    [FormerlySerializedAs("_house")] [SerializeField]
    private Transform house;

    [SerializeField] private LayerMask _damageableLayerMask;
    [SerializeField] private LayerMask _interactiveLayerMask;
    private float _timer;
    [SerializeField] private PassivesController _passivesController;

    void Start()
    {
        _playerStats = new PlayerStats();
        uiController.VisualHpChange(_playerStats.HpChange(0));
        uiController.VisualOreChange(_playerStats.OreChange(0));
        uiController.VisualRageChange(_playerStats.rage.GetValue());
        _craftController = new CraftController();
        _playerStats.Skill1 = new GroundSlam();
        _playerStats.Skill2 = new ShockWave();
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
                uiController.CastSkill1(_playerStats.Skill1.GetSkillCD());
                _playerStats.Skill1.CastSkill(this.transform, _damageableLayerMask);
                PaySkillCost(_playerStats.Skill1);
            }

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (TryCastSkill(_playerStats.Skill2))
            {
                uiController.CastSkill2(_playerStats.Skill2.GetSkillCD());
                _playerStats.Skill2.CastSkill(this.transform, _damageableLayerMask);
                PaySkillCost(_playerStats.Skill2);
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("zei");
            Collider[] obj = Physics.OverlapSphere(transform.position, 1, _interactiveLayerMask);
            if (obj.Length != 0)
            {
                Debug.Log("zei1");
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
            mouseController.StartCrafting(_craftController.Craft(house, transform));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseController.StopCrafting();
        }

        _playerStats.Skill1.Timer -= Time.deltaTime;
        _playerStats.Skill2.Timer -= Time.deltaTime;
        _timer -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        uiController.VisualHpChange(_playerStats.HpChange(-1));
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
                uiController.VisualRageChange(_playerStats.rage.GetValue());
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<IDamageableObject>().TakeDamage(_playerStats.BaseAttackStats.GetValue());
                }


            }

        }
    }

    public void OreChange(int change)
    {
        uiController.VisualOreChange(_playerStats.OreChange(change));

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
        uiController.VisualHpChange(_playerStats.HpChange(3));
    }

    private bool TryCastSkill(ISkill skill)
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

    private bool CheckSkillCost(ISkill skill)
    {
        switch (skill.CostType)
        {
            case "Rage": return skill.Cost <= _playerStats.rage.GetValue();
            
        }

        return false;
    }

    private void PaySkillCost(ISkill skill)
    {
        switch (skill.CostType)
        {
            case "Rage":
                _playerStats.rage.SetValue(_playerStats.rage.GetValue() - skill.Cost);
                uiController.VisualRageChange(_playerStats.rage.GetValue());

                break;
        }
    }

    public void AddPassive(Passives passive)
    {
        _passivesController.AddPassive(_playerStats, passive);
    }

}
