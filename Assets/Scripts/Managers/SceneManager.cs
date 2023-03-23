using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    public class SceneManager : MonoBehaviour
    {
        private ScoreManager _manager;
        private Transform _portalSpawner;
        [SerializeField] private GameObject _exitPortalPrefab;


        private void Start()
        {
            _manager = GetComponent<ScoreManager>();
            _portalSpawner = GameObject.FindGameObjectWithTag("Portal").transform;
        }

        public void PortalOpener()
        {
            Instantiate(_exitPortalPrefab, _portalSpawner.position, Quaternion.identity);
            _manager.IsActive = false;
        }
    }
}