using UnityEngine;

namespace Enemy
{
    public class LifeEnemy : MonoBehaviour
    {
        private TargetZone _targetZone;

        private void Start()
        {
            _targetZone = transform.parent.GetComponent<TargetZone>();
            _targetZone.AddEnemy(gameObject);
        }

        public void Killed()
        {
            _targetZone.EnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
}
