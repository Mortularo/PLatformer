using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace SAM
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _shotPos;
        [SerializeField] private float FireRate = 0.25f;
        [SerializeField] private GameObject Bullet;
        public bool IsDetected;
        private Vector2 _direction;
        private float _nextShotTime = 0;

        void Update()
        {
            Vector2 TargetPosition = _target.position;
            _direction = TargetPosition - (Vector2)_shotPos.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(_shotPos.position,
                                                     _direction,
                                                     _enemy.detectingRange);
            if (rayInfo)
            {
                if(rayInfo.collider.gameObject.tag == "Player")
                {
                    
                    if(IsDetected == false)
                    {
                        IsDetected = true;
                    }
                }
                else
                {
                    if (IsDetected == true)
                    {
                        IsDetected = false;
                    }
                }
            }
            if (IsDetected)
            {
                if (Time.time > _nextShotTime)
                {
                    _nextShotTime = Time.time + 1 / FireRate;
                    Shoot();
                }
            }
        }
        private void Shoot()
        {
            GameObject newBullet = PoolManager.GetObject("Fireball",
                                                         _shotPos.position,
                                                         _shotPos.rotation);
            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(_direction * _bullet._startSpeed, ForceMode2D.Impulse);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_shotPos.position, _enemy.detectingRange);
            Gizmos.DrawRay(_shotPos.position, _direction);
        }
    }
}