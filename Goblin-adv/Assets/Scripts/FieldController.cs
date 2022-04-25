using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldController : MonoBehaviour
{
    private Cell[,] _field;
    private float _widthUnit;
    private float _heightUnit;
    private Vector2 _leftUpCorner;
    private Vector2 _rightDownCorner;
    private Vector2 _cellSize;
    [SerializeField] private GameObject ore;
    private (int,int) _targetCell;
    public void CreateField(Vector2 firstCorner, Vector2 secondCorner,int height, int width)
    {
        _leftUpCorner.x = Mathf.Min(firstCorner.x, secondCorner.x);
        _leftUpCorner.y = Mathf.Max(firstCorner.y, secondCorner.y);
        _rightDownCorner.x = Mathf.Max(firstCorner.x, secondCorner.x);
        _rightDownCorner.y = Mathf.Min(firstCorner.y, secondCorner.y);
        _widthUnit = _rightDownCorner.x - _leftUpCorner.x;
        _heightUnit = _leftUpCorner.y - _rightDownCorner.y;
        _cellSize = new Vector2(_widthUnit / width, _heightUnit / height);
        _field = new Cell[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                _field[i, j] = new Cell();
                _field[i, j]
                    .InitializeCell(
                        new Vector2(_leftUpCorner.x + _cellSize.x * i, _rightDownCorner.y + _cellSize.y * j),
                        _cellSize);
                if (Random.value > 0.5)
                {
                    Instantiate(ore, _field[i, j].CenterCoordinatesWorld, Quaternion.identity);
                    _field[i, j]._empty = false;
                }
            }
        }

        Debug.Log(_field);
    }

    private void Start()
    {
        CreateField(new Vector2(-50, 50), new Vector2(50, -50), 100, 100);
    }

    public bool PositionIsEmpty(Vector3 coordinates)
    {
        _targetCell  =( Mathf.FloorToInt(((coordinates.x - _leftUpCorner.x) / _cellSize.x)),Mathf.FloorToInt(((coordinates.z - _rightDownCorner.y) / _cellSize.y)));
        return _field[_targetCell.Item1,_targetCell.Item2]._empty;
    }

    public Vector3 PlaceInCell(Vector3 coordinates)
    {
        _targetCell  =( Mathf.FloorToInt(((coordinates.x - _leftUpCorner.x) / _cellSize.x)),Mathf.FloorToInt(((coordinates.z - _rightDownCorner.y) / _cellSize.y)));
        return _field[_targetCell.Item1, _targetCell.Item2].CenterCoordinatesWorld;
    }
}
