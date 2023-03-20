using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private ScoreManager _manager;

        public void Start()
        {
            _manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreManager>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _manager.ScoreUpdate();
                Destroy(gameObject);
            }
        }

    }
}