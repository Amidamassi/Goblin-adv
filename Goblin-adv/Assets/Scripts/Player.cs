using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Vector3 _playermovement;
    private PlayerStats _playerStats;
    [SerializeField] private UiController uiController;
    private CraftController _craftController;
    [SerializeField] private MouseController mouseController;
    [FormerlySerializedAs("_house")] [SerializeField] private Transform house;
    [SerializeField] private LayerMask _damageableLayerMask;
    private float _timer;
    void Start()
    {
        _playerStats = new PlayerStats();
        uiController.VisualHpChange(_playerStats.HpChange(0));
        _craftController = new CraftController();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playermovement.z=+1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _playermovement.z=-1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _playermovement.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _playermovement.x=-1;
        }

        transform.Translate(_playerStats.speed*Time.deltaTime *_playermovement.normalized);

        _playermovement = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            mouseController.StartCrafting(_craftController.Craft(house, transform));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseController.StopCrafting();
        }

        _timer -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("коллизия");
        if ((collision.transform.GetComponent(typeof(EnemyBehavior)) as EnemyBehavior).objectType == "enemy")
        {
            uiController.VisualHpChange(_playerStats.HpChange(-1));
        }
    }

    public void DealAttack(Vector3 attackCenter)
    {
        if(_timer <=0){
        Collider[] enemies = Physics.OverlapSphere(attackCenter, _playerStats.attackRadius,_damageableLayerMask);
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<IDamageableObject>().TakeDamage(_playerStats.damage);
            }

            _timer = _playerStats.attackCD;
        }
        
        }
    }
}
