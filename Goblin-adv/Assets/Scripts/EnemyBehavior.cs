using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    public float speed;
    public string objectType;
    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        _position += speed * Time.deltaTime * (player.position - _position);
        transform.position = _position;
    }

    public void ChangeTarget(Transform player)
    {
        this.player = player;
    }

    public EnemyBehavior(Transform player)
    {
        this.player = player;
        objectType = "enemy";
    }

  //  private void OnCollisionEnter(Collision collision)
   // {
   //     if (collision.transform == player.transform)
   //     {
   //         Debug.Log("коллизия");
    //        Destroy(gameObject);
    //    }
   // }

    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
    }
}
