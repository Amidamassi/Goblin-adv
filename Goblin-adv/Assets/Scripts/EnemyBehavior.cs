using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour,IDamageableObject
{
    // Start is called before the first frame update
    [SerializeField] private Player player;
    public float speed;
    public string objectType;
    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * (player.transform.position - transform.position).normalized);
        
    }

    public void ChangeTarget(Player player)
    {
        this.player = player;
    }

    public EnemyBehavior(Player player)
    {
        this.player = player;
        objectType = "enemy";
    }
    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
    }
}
