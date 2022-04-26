using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AiController : MonoBehaviour
{
  [SerializeField] private Player player;
  public float spawnCd;
  public float minSpawnRange;
  public float maxSpawnRange;
  [SerializeField] private Transform enemy;
  private Vector3 _randomPosition;
  private Transform _enemyClone;
  
  void Start()
  {
    StartSpawnEnemy();
  }

  private async void StartSpawnEnemy()
  {
    while (true)
    {
      await UniTask.Delay(TimeSpan.FromSeconds(spawnCd));
      
      _randomPosition = new Vector3(Random.Range(minSpawnRange,maxSpawnRange)*RandomSign(), 0, Random.Range(minSpawnRange, maxSpawnRange)*RandomSign());
      _enemyClone = Instantiate(enemy, player.transform.position + _randomPosition, Quaternion.identity);
      EnemyBehavior enemyBehavior = _enemyClone.GetComponent<EnemyBehavior>();
      enemyBehavior.ChangeTarget(player.transform);
      enemyBehavior.InitDeadAction(OnDeadAction);
      if (Random.value > 0.5)
      {
        enemyBehavior.SelectEnemyType(new RangeEnemy());
      }
      else
      {
        enemyBehavior.SelectEnemyType(new MeleeEnemy());
      }
      enemyBehavior.objectType = "enemy";
    }
  }

  private void OnDeadAction(float obj)
  {
    Debug.Log(obj);
  }

  private int RandomSign()
  {
    if (Random.value > 0.5)
    {
      return -1;
    }
    else
    {
      return 1;
    }
  }
}
