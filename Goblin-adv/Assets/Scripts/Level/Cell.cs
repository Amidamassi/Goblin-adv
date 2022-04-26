using UnityEngine;


    public class Cell
    {
        public Vector2 Coordinates = new Vector2();
        public Vector2 CenterCoordinates;
        public Vector3 CoordinatesWorld;
        public Vector3 CenterCoordinatesWorld;
        public bool _empty=true;

        public void InitializeCell(Vector2 coordinates,Vector2 cellSize)
        {
            Coordinates = coordinates;
            CoordinatesWorld = new Vector3(coordinates.x, 0, coordinates.y);
            CenterCoordinates = coordinates + cellSize / 2;
            CenterCoordinatesWorld = new Vector3(coordinates.x+cellSize.x/2, 0.5f, coordinates.y+cellSize.y/2);
        }
        
    }