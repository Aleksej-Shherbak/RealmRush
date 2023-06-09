﻿using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class GridManager: MonoBehaviour
    {
        [SerializeField] private Vector2Int gridSize;
        private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
        public Dictionary<Vector2Int, Node> Grid => grid;

        void Awake()
        {
            CreateGrid();
        }

        public Node GetNode(Vector2Int coordinates)
        {
            return grid.TryGetValue(coordinates, out var res) ? res : null;
        }

        private void CreateGrid()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    var coordinates = new Vector2Int(x, y);
                    grid.Add(coordinates, new Node(coordinates, true));
                }   
            }   
        }
    }
}