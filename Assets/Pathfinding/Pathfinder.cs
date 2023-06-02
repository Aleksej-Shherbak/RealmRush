using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Pathfinder: MonoBehaviour
    {
        [SerializeField] private Node currentSearchNode;
        
        Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
        private GridManager gridManager;
        private Dictionary<Vector2Int, Node> grid;
        
        private void Awake()
        {
            gridManager = FindObjectOfType<GridManager>();

            if (gridManager != null)
                grid = gridManager.Grid;
        }

        void Start()
        {
            ExploreNeighbors();
        }

        void ExploreNeighbors()
        {
            var neighbors = new List<Node>();

            foreach (var direction in directions)
            {
                var neighborCoordinates = currentSearchNode.coordinates + direction;

                if (grid.ContainsKey(neighborCoordinates))
                {
                    neighbors.Add(grid[neighborCoordinates]);
                    
                    // TODO: remove after testing... 
                    grid[neighborCoordinates].isExplored = true;
                    grid[currentSearchNode.coordinates].isPath = true;
                }
            }
        }
    }
}