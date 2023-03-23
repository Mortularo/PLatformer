using System.Collections;
using System.Collections.Generic;
using SAM;
using UnityEngine;

namespace SAM
{
    public static class PoolManager
    {
        private static PoolPart[] pools;
        private static GameObject objectsParent;
        [System.Serializable]
        public struct PoolPart
        {
            public string name; // ??? ???????
            public PoolObject prefab; // ??????
            public int count; // ????? ???????? ??? ????????????? ????
            public BulletPooling ammo;
        }
        public static void Initialize(PoolPart[] newPools)
        {
            pools = newPools;
            objectsParent = new GameObject();
            objectsParent.name = "Ammo";
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].prefab != null)
                {
                    pools[i].ammo = new BulletPooling(); // ????????? ??? ??? ??????? ???????
                    pools[i].ammo.Initialize(pools[i].count, pools[i].prefab, objectsParent.transform);
                }
            }
        }
        public static GameObject GetObject(string name, Vector2 position, Quaternion rotation)
        {
            GameObject result = null;
            if (pools != null)
            {
                for (int i = 0; i < pools.Length; i++)
                {
                    if (string.Compare(pools[i].name, name) == 0)
                    {
                        result = pools[i].ammo.GetBullet().gameObject;
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive(true);
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
