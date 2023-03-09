using System;

namespace SAM
{
    [Serializable]
    public class Player
    {
        public float speed = 4f;
        public float jumpForce = 6f;
        public float attackRange = 0.5f;
        public float timeBtwAttacks = 0.5f;
        public int weaponDamage = 5;
        public int health = 15;
    }
}