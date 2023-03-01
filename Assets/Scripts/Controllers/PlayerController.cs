using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    public class PlayerController : MonoBehaviour
    {
        private static bool faceRight = true;
        private static bool IsGrounded;
        private float _moveInput, _startTimer, _checkRadius = 0.1f;
        private int _damage;
        private Rigidbody2D _rb;
        [SerializeField] private Transform _feetPos, _attackPos;
        [SerializeField] private LayerMask WhatIsGrounded, Enemy;
        [SerializeField] private Player _player;
        [SerializeField] private Animator animator;



        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            _damage = _player.weaponDamage;
        }

        void FixedUpdate()
        {
            Move();
            if (faceRight == false && _moveInput > 0)
            {
                Flip();
            }
            else if (faceRight == true && _moveInput < 0)
            {
                Flip();
            }
            if (_moveInput != 0)
            {
                animator.SetBool("IsRuning", true);
            }
            else
            {
                animator.SetBool("IsRuning", false);
            }

        }
        private void Update()
        {
            IsGrounded = Physics2D.OverlapCircle(_feetPos.position, _checkRadius, WhatIsGrounded);
            if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (IsGrounded == true)
            {
                animator.SetBool("IsJumping", false);
            }
            else if (IsGrounded == false)
            {
                animator.SetBool("IsJumping", true);
            }
            if (_player.timeBtwAttacks <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SlashAttack();
                }
                _player.timeBtwAttacks = _startTimer;
            }
            else
            {
                _player.timeBtwAttacks -= Time.deltaTime;
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPos.position, _player.attackRange);
        }
        #region Methods
        public void Flip()
        {
            faceRight = !faceRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        public void Jump()
        {
            _rb.velocity = Vector2.up * _player.jumpForce;
        }
        public void Move()
        {
            _moveInput = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(_moveInput * _player.speed, _rb.velocity.y);
        }
        public void SlashAttack()
        {
            animator.SetTrigger("Attack");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPos.position, _player.attackRange, Enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().DamageGot(_damage);
            }
        }
        #endregion
    }
}