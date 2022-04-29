using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Stats
{
    public class PassivesController:MonoBehaviour
    {
        private Passives _passives;
        [SerializeField] private ConfigPassives _configPassives;

        [SerializeField] private Player _player;
        public void AddPassive(PlayerStats playerStats,Passives passive)
        {  
            if(passive.type == "StatsBuff")
                switch (passive.stat)
            {
                case StatsEnum.Hp:
                    playerStats.hp.SetBaseValue(playerStats.hp.GetBaseValue()+passive.Value);
                    break;
                case StatsEnum.Speed:
                    playerStats.speed.SetValue(playerStats.speed.GetValue()+passive.Value);
                    break;
                case StatsEnum.BaseAttackStats:
                    playerStats.BaseAttackStats.SetValue(playerStats.BaseAttackStats.GetValue()+passive.Value);
                    break;
                case StatsEnum.Rage:
                    playerStats.rage.SetValue(playerStats.rage.GetValue()+passive.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Passives[] GetAviableRandomPassives(int numberOfPassives)
        {
            Passives[] passives = new Passives[numberOfPassives];
            for (int i = 0; i < numberOfPassives; i++)
            {
                passives[i] = _configPassives._list[Mathf.FloorToInt(Random.Range(0f, _configPassives._list.Count))];
            }

            return passives;
        }
    }
}