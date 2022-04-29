using System;
using UnityEngine;

namespace DefaultNamespace.Level
{
    public class TradeHouse:MonoBehaviour,IInteractive
    {
        private Action<Vector3> _initOpenTradeHouseInitOpenTradeHouse;
        [SerializeField] private UiController _uiController;
        public Cell cell;
        public void Action()
        {
            _initOpenTradeHouseInitOpenTradeHouse.Invoke(transform.position);
            gameObject.SetActive(false);
        }

        public void InitOpenTradeHouse(Action<Vector3> action)
        {
            _initOpenTradeHouseInitOpenTradeHouse = action;
        }
    }
}