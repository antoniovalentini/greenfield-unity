using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapProject.MainScripts
{
    public class ChunkGenerator
    {
        List<Coord> allTileCoords;
        Queue<Coord> shuffledTileCoords;

        public Transform GenerateChunks(Vector2 chunkSize, int seed, Transform groundPrefab, Transform treePrefab, int treesCount, float outlinePercent)
        {
            var chunkHolder = new GameObject().transform;

            // generating ground tiles
            allTileCoords = new List<Coord>();
            for (int x = 0; x < chunkSize.x; x++)
            {
                for (int y = 0; y < chunkSize.y; y++)
                {
                    var tilePosition = CoordToPosition(x, y);
                    var newTile = GameObject.Instantiate(groundPrefab, tilePosition, Quaternion.Euler(Vector3.zero)) as Transform;
                    newTile.name = string.Format("Tile_{0}-{1}", x, y);
                    newTile.localScale = newTile.localScale * (1 - outlinePercent);
                    newTile.parent = chunkHolder;
                    allTileCoords.Add(new Coord(x, y));
                }
            }

            shuffledTileCoords = new Queue<Coord>(Utilities.ShuffleArray(allTileCoords.ToArray(), seed));

            // generating trees
            // trees are translated 0.05 upper
            for (int i = 0; i < treesCount; i++)
            {
                var randomCoord = GetRandomCoord();
                var treePosition = CoordToPosition(randomCoord._x, randomCoord._y);
                var newTree = GameObject.Instantiate(treePrefab, treePosition + Vector3.up * 0.05f, Quaternion.identity) as Transform;
                newTree.name = string.Format("Tree_{0}-{1}", randomCoord._x, randomCoord._y);
                newTree.parent = chunkHolder;
            }

            return chunkHolder;
        }

        // use a random coord from top, then put it back at the bottom
        private Coord GetRandomCoord()
        {
            var randomCoord = shuffledTileCoords.Dequeue();
            shuffledTileCoords.Enqueue(randomCoord);
            return randomCoord;
        }

        // easy and handy conversiont from map coordinate to object position
        Vector3 CoordToPosition(int x, int y)
        {
            return new Vector3(x, 0, y);
        }

    }

    public struct Coord
    {
        public int _x;
        public int _y;

        public Coord(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}