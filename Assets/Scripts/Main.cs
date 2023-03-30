using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private TileMapManager _manager;
        private TileMapController _controller;

        private void Awake()
        {
            _controller = new TileMapController(_manager);
            _controller.Start();
        }
    }
}