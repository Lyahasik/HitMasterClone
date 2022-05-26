using Enemy;
using UnityEngine;

namespace Player
{
    public class BulletFlight : MonoBehaviour
    {
        [SerializeField] private float impulsePower;
        private void Start()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * impulsePower);
        }

        private void OnTriggerEnter(Collider other)
        {
            LifeEnemy lifeEnemy = other.GetComponent<LifeEnemy>();
            
            if (lifeEnemy)
                lifeEnemy.Killed();
            
            Destroy(gameObject);
        }
    }
}
