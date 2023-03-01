using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    [Serializable]
    public class Player
    {
        public float speed = 4f;
        public float jumpForce = 6f;
        public float attackRange = 0.42f;
        public float timeBtwAttacks = 0.5f;
        public int weaponDamage = 1;
        public int health = 15;
    }
}