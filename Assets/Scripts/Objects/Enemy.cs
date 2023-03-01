using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    [Serializable]
    public class Enemy
    {
        public float speed = 3f;
        public float jumpForce = 5f;
        public float attackRange = 0.42f;
        public float timeBtwAttacks = 0.5f;
        public int weaponDamage = 1;
        public int health = 10;
    }
}