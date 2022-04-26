using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ProjectileController : MonoBehaviour
{
    private Transform _target;
    public float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * (_target.transform.position - transform.position).normalized);
    }

    public void ChangeTarget(Transform transform)
    {
        _target = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
        }
        
    }
}
