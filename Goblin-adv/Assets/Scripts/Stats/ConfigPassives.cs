using System;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Passives", order = 1)]
    public class ConfigPassives : ScriptableObject
    {
        public List<Passives> _list;
    }
    [Serializable]
    public class Passives
    {
        public string type;
        public StatsEnum stat;
        public float Value;
        public string Name;
    }
