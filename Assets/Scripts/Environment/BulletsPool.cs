using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class BulletsPool : MonoBehaviour
    {
        private Queue<GameObject> _bullets = new Queue<GameObject>();

        public void AddBullet(GameObject gameObject)
        {
            _bullets.Enqueue(gameObject);
        }

        public GameObject TryGetBullet()
        {
            return (_bullets.Count > 0) ? _bullets.Dequeue() : null;
        }
    }
}
