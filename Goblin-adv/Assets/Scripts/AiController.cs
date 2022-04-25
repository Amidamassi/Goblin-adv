using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AiController : MonoBehaviour
{
  [FormerlySerializedAs("_player")] [SerializeField] private Player player;
  public float spawnCd;
  public float spawnRange;
  [SerializeField] private Transform enemy;
  private Vector3 _randomPosition;
  private Transform _enemyClone;

  void Start()
  {
  //  StartSpawnEnemy();
  }

  private async void StartSpawnEnemy()
  {
    while (true)
    {
      await UniTask.Delay(TimeSpan.FromSeconds(spawnCd).Milliseconds);
      
      _randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
      _enemyClone = Instantiate(enemy, player.transform.position + _randomPosition, Quaternion.identity);
      EnemyBehavior enemyBehavior = _enemyClone.GetComponent<EnemyBehavior>();
      enemyBehavior.ChangeTarget(player);
      enemyBehavior.objectType = "enemy";
    }
  }
}
