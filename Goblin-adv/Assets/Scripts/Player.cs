using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _playermovement;
    private PlayerStats _playerStats;
    [SerializeField] private UiController _uiController;
    [SerializeField] private CraftController _craftController;
    [SerializeField] private Transform _house;
    void Start()
    {
        _playerStats = new PlayerStats();
        _uiController.VisualHpChange(_playerStats.HpChange(0));
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

        transform.Translate(_playermovement.normalized*_playerStats.speed*Time.deltaTime);

        _playermovement = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _craftController.Craft(_house,transform);
        }

        if (_craftController.craftActive == true)
        {
            _craftController.MoveCraftedObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.GetComponent(typeof(EnemyBehavior)) as EnemyBehavior).objectType == "enemy")
        {
            _uiController.VisualHpChange(_playerStats.HpChange(-1));
        }
    }
}
