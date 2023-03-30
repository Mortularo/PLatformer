using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SAM
{
    public class TileMapManager : MonoBehaviour
    {
        public Tilemap tilemap;
        public Tile tile;
        public int mapHeight, mapWidth;
        [Range (0, 100)] public int fillPercent, smoothPercent;
        public bool hasBorders = true;
    }
}