using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _playermovement;
    private GoblinStats _goblinStats;
    [SerializeField] private UiController _uiController;
    void Start()
    {
        _goblinStats = new GoblinStats();
        _uiController.VisualHpChange(_goblinStats.HpChange(0));
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

        transform.Translate(_playermovement.normalized*_goblinStats.speed*Time.deltaTime);

        _playermovement = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.GetComponent(typeof(EnemyBehavior)) as EnemyBehavior).objectType == "enemy")
        {
            _uiController.VisualHpChange(_goblinStats.HpChange(-1));
        }
    }
}
