using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace SAM {
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Bullet _bullet;
        private PlayerController _playerCon;
        //private float curentRotation;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Animator animator;
        //[SerializeField] private Transform _shotPos;
        [SerializeField] private Vector2 _targetDirection;

        public int Health;
        public float Speed, DetectingRange;
        //private bool IsDetected = false;
        [SerializeField] private Transform _targetPos;
        //private float nextShotTime = 0;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            _targetPos = GameObject.FindGameObjectWithTag("Player").transform;
            Health = _enemy.health;
            Speed = _enemy.speed;
            DetectingRange = _enemy.detectingRange;
            _playerCon = FindObjectOfType<PlayerController>();
        }
        void Update()
        {
            Flip();
            if (Health <= 0)
            {
                Die();
            }
            //Vector2 localTargetPos = _targetPos.position;
            //_targetDirection = localTargetPos - (Vector2)transform.position;
            //RaycastHit2D hitInfo = Physics2D.Raycast(_shotPos.position, _targetDirection, DetectingRange);
            
            //if (hitInfo)
            //{
            //    if (hitInfo.collider.CompareTag("Player"))
            //    {
            //        Debug.Log("" + hitInfo.collider.name);
            //        if (IsDetected == false)
            //        {
            //            Debug.Log("Target detected");
            //            IsDetected = true;
            //        }
            //    }
            //    else
            //    {
            //        if (IsDetected == true)
            //        {
            //            Debug.Log("Target lost");
            //            IsDetected = false;
            //        }
            //    }
            //    if (IsDetected)
            //    {
            //        _shotPos.up = _targetDirection;
            //        if (Time.time > nextShotTime)
            //        {
            //            nextShotTime = Time.time + 1 / _enemy.fireRate;
            //            Shoot();
            //        }
            //    }
            //}
        }
        #region Methods
        public void Move()
        {
            animator.SetBool("IsMoving", true);
            transform.position = Vector2.MoveTowards(transform.position,
                                                     _playerCon.transform.position,
                                                     _enemy.speed * Time.deltaTime);
        }
        public void Flip()
        {
            if (_playerCon.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //curentRotation = 1f;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                //curentRotation = -1f;
            }
        }
        public void DamageGot(int damage)
        {
            Health -= damage;
        }
        
        public void Die()
        {
            Destroy(gameObject);
        }

        //private void Shoot()
        //{
        //    GameObject newBullet = PoolManager.GetObject("Fireball", _shotPos.position, _shotPos.rotation);
        //    Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        //    bulletRB.AddForce(_shotPos.up * _bullet._startSpeed , ForceMode2D.Impulse);
        //}
        #endregion

    }
}