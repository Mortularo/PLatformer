using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

namespace SAM
{
    public class PatrolController : MonoBehaviour
    {
        [SerializeField] private Goblin _enemy;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Transform _transform;
        List<Transform> points = new List<Transform>();
        private Transform _player;
        private Transform _target;
        private Vector2 _direction;
        public float _speed;
        public bool IsDetected;


        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _transform = GetComponent<Transform>();
            _speed = _enemy.speed;
            Transform patrolPoints = GameObject.FindGameObjectWithTag("PatrolPoints").transform;
            foreach (Transform t in patrolPoints)
            {
                points.Add(t);
            }
            _target = points[Random.Range(0, points.Count)];
            IsDetected = false;
        }

        void Update()
        {
            Vector2 TargetPosition = _player.position;
            _direction = TargetPosition - (Vector2)transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,
                                                     _direction,
                                                     _enemy.detectingRange);
            Debug.Log(rayInfo.collider.gameObject.tag);
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == "Player")
                {

                    if (IsDetected == false)
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
                Chase();
            }
            else
            {
                Choose();
                Move();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform == _target)
            {
                Choose();
            }
        }

        #region Methods
        public void Move()
        {
            transform.position = Vector2.MoveTowards(_transform.position,
                    _target.position, _speed * Time.deltaTime);
        }
        public void Chase()
        {
            transform.position = Vector2.MoveTowards(_transform.position,
                    _player.position, _speed * Time.deltaTime);
        }
        public void Choose()
        {
            _target = points[Random.Range(0, points.Count)];
        }
        #endregion
    }
}