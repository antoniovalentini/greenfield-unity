using System;
using System.Collections.Generic;
using UnityEngine;

namespace MapProject.MainScripts
{
    public class MapGenerator : MonoBehaviour
    {
        public Vector2 mapSize;
        public Vector2 chunkSize;
        public int seed = 88;
        public int treesForEachChunk = 8;
        public Transform groundTilePrefab;
        public Transform treePrefab;
        [Range(0,1)]
        public float outlinePercent = 0.1f;

        public string mapHolderName = "";

        public void GenerateMap()
        {
            // check on prefabs
            if (groundTilePrefab == null || treePrefab == null) return;

            // check on MapHolder name
            if (string.IsNullOrEmpty(mapHolderName)) mapHolderName = "MapHolder";

            // check we have a consistent map size
            if (mapSize.x <= 0) mapSize.x = 1;
            if (mapSize.y <= 0) mapSize.y = 1;

            // check we have a consistent chunk size
            if (chunkSize.x <= 0) chunkSize.x = 1;
            if (chunkSize.y <= 0) chunkSize.y = 1;

            // check we have a consistent number of trees
            if (treesForEachChunk < 0) treesForEachChunk = 0;
            if (treesForEachChunk > chunkSize.x * chunkSize.y) treesForEachChunk = (int)(chunkSize.x * chunkSize.y);

            // if already exists, destroy it (we'll create a new one
            if (transform.FindChild(mapHolderName))
            {
                DestroyImmediate(transform.FindChild(mapHolderName).gameObject);
            }
            var mapHolder = new GameObject(mapHolderName).transform;
            mapHolder.parent = transform;

            // chunk generation
            // each chunk is made by tiles
            var chunkGenerator = new ChunkGenerator();
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    var newChunk = chunkGenerator.GenerateChunks(chunkSize, (seed+x+y), groundTilePrefab, treePrefab, treesForEachChunk, outlinePercent);
                    var chunkPosition = new Vector3(x*chunkSize.x, 0, y*chunkSize.y);
                    newChunk.position = chunkPosition;
                    newChunk.name = string.Format("Chunk_{0}-{1}", x, y);
                    newChunk.parent = mapHolder;
                }
            }
        }
    }
}
