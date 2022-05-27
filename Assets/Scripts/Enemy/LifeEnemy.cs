using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class LifeEnemy : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private int _currentHealth;
        [SerializeField] private Image healthBar;
        
        private TargetZone _targetZone;

        private void Start()
        {
            _currentHealth = maxHealth;
            
            _targetZone = transform.parent.GetComponent<TargetZone>();
            _targetZone.AddEnemy(gameObject);
        }

        public void TakeDamage()
        {
            _currentHealth--;

            healthBar.fillAmount = (float)_currentHealth / maxHealth;
            
            if (_currentHealth <= 0)
                Killed();
        }

        private void Killed()
        {
            _targetZone.EnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
}
