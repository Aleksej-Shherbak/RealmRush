using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Pathfinder: MonoBehaviour
    {
        [SerializeField] private Vector2Int startCoordinates;
        [SerializeField] private Vector2Int destinationCoordinates;
        
        private Node currentSearchNode;
        private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
        private GridManager gridManager;
        private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
        private Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
        private Queue<Node> frontier = new Queue<Node>();
        private Node startNode;
        private Node destinationNode;
        
        private void Awake()
        {
            gridManager = FindObjectOfType<GridManager>();

            if (gridManager != null)
                grid = gridManager.Grid;

            startNode = new Node(startCoordinates, true);
            destinationNode = new Node(destinationCoordinates, true);
        }

        void Start()
        {
            BreadFirstSearch();
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
                    
                }
            }

            foreach (var neighbor in neighbors)
            {
                if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
                {
                    reached.Add(neighbor.coordinates, neighbor);
                    frontier.Enqueue(neighbor);
                }
            }
        }

        void BreadFirstSearch()
        {
            var isRunning = true;
            
            frontier.Enqueue(startNode);
            reached.Add(startCoordinates, startNode);

            while (frontier.Count > 0 && isRunning)
            {
                currentSearchNode = frontier.Dequeue();
                currentSearchNode.isExplored = true;
                ExploreNeighbors();

                if (currentSearchNode.coordinates == destinationCoordinates)
                {
                    isRunning = false;
                }
            }
        }
    }
}