using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class God : MonoBehaviour
{
    [SerializeField] private UiController _uiController;
    [SerializeField] private Player _player;
    [SerializeField] private FieldController _fieldController;
    [SerializeField] private MouseController _mouseController;

    private void Start()
    {
        Initialize();
        PassActions();
        
    }

    private void Initialize()
    {
        _player.Initialize();
        _fieldController.Initialize();
        _mouseController.Initialize(_player.transform);
    }

    private void PassActions()
    {
        _player.StartCraft(_mouseController.StartCrafting);
        _player.StopCraft(_mouseController.StopCrafting);
        _mouseController.DealAttack(_player.DealAttack);
        _mouseController.PlaceInCell(_fieldController.PlaceInCell);
        _mouseController.IsPositionEmpty(_fieldController.PositionIsEmpty);
        _uiController.AddPassiveTraderWindow(_player.AddPassive);
    }
}