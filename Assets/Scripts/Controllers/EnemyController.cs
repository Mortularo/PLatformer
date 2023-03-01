using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM {
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Animator animator;
        public int Health;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            Health = _enemy.health;
        }

        void Update()
        {
            if (Health <= 0)
            {
                Die();
            }
        }
        #region Methods
        public void DamageGot(int damage)
        {
            Health -= damage;
        }
        public void Die()
        {
            Destroy(gameObject);
        }
        #endregion
    }
}