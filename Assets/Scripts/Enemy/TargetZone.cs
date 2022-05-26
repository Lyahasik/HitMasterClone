using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class TargetZone : MonoBehaviour
    {
        private readonly LinkedList<GameObject> _enemies = new LinkedList<GameObject>();

        public void AddEnemy(GameObject enemy)
        {
            _enemies.AddLast(enemy);
        }

        public void EnemyKilled(GameObject gameObject)
        {
            _enemies.Remove(gameObject);

            if (_enemies.Count <= 0)
                GoalManager.TargetAreaCleared();
        }
    }
}
