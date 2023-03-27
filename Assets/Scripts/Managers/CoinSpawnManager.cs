using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    public class CoinSpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _coin;
        [SerializeField] private GameObject _sp;
        List<Transform> SpawnPoints = new List<Transform>();
        
        void Start()
        {
            Transform pointCollector = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            foreach (Transform t in pointCollector)
            {
                SpawnPoints.Add(t);
                //Debug.Log(t.position);
            }
            foreach (Transform point in SpawnPoints)
            {
                Instantiate(_coin, point.position, Quaternion.identity);
            }
        }
    }
}