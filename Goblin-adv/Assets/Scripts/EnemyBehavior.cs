using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform goblin;
    public float speed;
    public string objectType;
    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        _position += speed * Time.deltaTime * (goblin.position - _position);
        transform.position = _position;
    }

    public void ChangeTarget(Transform player)
    {
        goblin = player;
    }

    public EnemyBehavior(Transform player)
    {
        goblin = player;
        objectType = "enemy";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == goblin.transform)
        {
            Debug.Log("коллизия");
            Destroy(gameObject);
        }
    }
}
