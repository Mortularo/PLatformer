using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAM
{
    [Serializable]
    public class Goblin
    {
        public float speed = 2f;
        public float jumpForce = 7f;
        public float attackRange = 0.5f;
        public float fireRate = 0f;
        public float detectingRange = 7f;
        public int weaponDamage = 5;
        public int health = 15;
    }
}