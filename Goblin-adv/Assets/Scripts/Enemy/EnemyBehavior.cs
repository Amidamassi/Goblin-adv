using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour,IDamageableObject
{
    // Start is called before the first frame update
    [FormerlySerializedAs("target")] [SerializeField] private Transform _target;
    public float speed;
    public string objectType;
    private Vector3 _position;
    public Enemy _enemy = new Enemy();
    [SerializeField] private Transform _RangeAttackProjectile;
    private float _attackTimer;
    private ProjectileController _projControllerectileController;
    private Transform _projectile;
    private Action<float> _onDeadAction;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        if ((_target.position - transform.position).magnitude > _enemy.baseAttackStats.AttackRadius)
        {
            transform.Translate(speed * Time.deltaTime * (_target.transform.position - transform.position).normalized);
        }
        else
        {
            if (_attackTimer < 0)
            {
                if (_enemy is MeleeEnemy)
                {
                    
                }
                else
                {
                    _projectile = Instantiate(_RangeAttackProjectile,this.transform);
                    _projControllerectileController = _projectile.GetComponent<ProjectileController>();
                    _projControllerectileController.speed = _enemy.projectileSpeed;
                    _projControllerectileController.ChangeTarget(_target);
                    _attackTimer = _enemy.baseAttackStats.AttackCD;

                }
            }
        }
        _attackTimer -= Time.deltaTime;
    }

    public void ChangeTarget(Transform target)
    {
        this._target = target;
    }

    public EnemyBehavior(Transform target)
    {
        this._target = target;
        objectType = "enemy";
    }
    public void TakeDamage(float damage)
    {
        _onDeadAction.Invoke(_enemy.reward);
        Destroy(gameObject);
    }

    public void LoseAllHp()
    {
         
    }

    public void SelectEnemyType(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void InitDeadAction(Action<float> onDeadAction)
    {
        _onDeadAction = onDeadAction;
    }
}
