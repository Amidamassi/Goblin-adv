using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiController : MonoBehaviour
{
    [SerializeField] private Transform goblin;
    public float spawnCd;
    public float spawnRange;
    [SerializeField] private Transform enemy;
    private Vector3 _randomPosition;
    private Transform _enemyClone;
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }


private IEnumerator EnemySpawner ()
{
    while (true)
    {
        yield return new WaitForSeconds(spawnCd);
        
        _randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange),0, Random.Range(-spawnRange, spawnRange));
        _enemyClone = Instantiate(enemy, goblin.position + _randomPosition,Quaternion.identity);
        EnemyBehavior enemyBehavior = _enemyClone.GetComponent(typeof(EnemyBehavior)) as EnemyBehavior;
        enemyBehavior.ChangeTarget(goblin);
        enemyBehavior.objectType= "enemy";

    }
}

}

