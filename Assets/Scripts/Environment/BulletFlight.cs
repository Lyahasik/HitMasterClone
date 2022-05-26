using UnityEngine;

using Enemy;

namespace Environment
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletFlight : MonoBehaviour
    {
        private BulletsPool _bulletsPool;
        private Rigidbody _rigidbody;
        
        [SerializeField] private float impulsePower;
        
        private void Start()
        {
            _bulletsPool = FindObjectOfType<BulletsPool>();
            _rigidbody = GetComponent<Rigidbody>();
            
            AddToPool();
        }

        public void StartMoving()
        {
            _rigidbody.AddForce(transform.forward * impulsePower);
        }

        private void OnTriggerEnter(Collider other)
        {
            LifeEnemy lifeEnemy = other.GetComponent<LifeEnemy>();
            
            if (lifeEnemy)
                lifeEnemy.Killed();

            AddToPool();
        }

        private void AddToPool()
        {
            _bulletsPool.AddBullet(gameObject);
            transform.parent = _bulletsPool.transform;
            _rigidbody.velocity = Vector3.zero;
            transform.position = Vector3.zero;
        }
    }
}
