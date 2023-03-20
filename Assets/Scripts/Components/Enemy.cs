using System;

namespace SAM
{
    [Serializable]
    public class Enemy
    {
        public float speed = 4f;
        public float jumpForce = 6f;
        public float attackRange = 0.5f;
        public float fireRate = 1f;
        public float detectingRange = 7f;
        public int weaponDamage = 5;
        public int health = 15;
    }
}