using System.Collections;
using System.Collections.Generic;
using SAM;
using UnityEngine;

namespace SAM
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private PlayerController _player;
        public int Damage;

        void Start()
        {
            Damage = _bullet._damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (collision.gameObject.CompareTag("Player"))
            {
                _player.DamageGot(_bullet._damage);
                GetComponent<PoolObject>().ReturnToPool();
            }
            else if (collision.gameObject.CompareTag("Scenery"))
            {
                GetComponent<PoolObject>().ReturnToPool();
            }
        }
    }
}