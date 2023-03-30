using UnityEngine;
using UnityEngine.Tilemaps;

namespace SAM
{
    public class TileMapController
    {
        private Tilemap _tilemap;
        private Tile _tile;
        private int _mapHeight, _mapWidth;
        private int[,] _map;
        private int _fillPercent, _smoothPercent;
        private bool _hasBorders;

        public TileMapController(TileMapManager view)
        {
            _tilemap = view.tilemap;
            _tile = view.tile;
            _mapHeight = view.mapHeight;
            _mapWidth = view.mapWidth;

            _fillPercent = view.fillPercent;
            _smoothPercent = view.smoothPercent;

            _hasBorders = view.hasBorders;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void Start()
        {
            FillMap();
            for (int i = 0; i < _smoothPercent; i++) SmoothMap();
            DrawTiles();
        }
        #region Methods
        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    //if (x == 0 || x == _mapWidth -1 || y == 0 || y == _mapHeight-1)
                    //{
                    //    if (_hasBorders)
                    //    {
                    //        _map[x, y] = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    //}
                }
            }
        }
        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int _neighbourCount = GetNeighbour(x,y);
                    if (_neighbourCount > 4) _map[x, y] = 1;
                    else if (_neighbourCount < 4) _map[x, y] = 0;
                }
            }
        }
        private void DrawTiles()
        {
            if (_map == null) return;
            else
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    for (int y = 0; y < _mapHeight; y++)
                    {
                        if (_map[x,y] == 1)
                        {
                            Vector3Int _tilePos = new Vector3Int (-_mapWidth/2+x, _mapHeight/2 +y, 0);

                            _tilemap.SetTile(_tilePos, _tile);
                        }
                    }
                }
            }
        }
        private int GetNeighbour(int x, int y)
        {
            int _neighbourCount = 0;
            for (int gridX = x-1; gridX <= x+1; gridX++)
            {
                for (int gridY = y-1; gridY <= y+1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            _neighbourCount += _map[gridX, gridY];
                        }
                    }
                    else _neighbourCount++;
                }
            }
            return _neighbourCount;
        }
        #endregion
    }
}