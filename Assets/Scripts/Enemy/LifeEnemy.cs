using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    public class LifeEnemy : MonoBehaviour
    {
        private Animator animator;
        private TargetZone _targetZone;

        [Space]
        [SerializeField] private GameObject canvas;
        [SerializeField] private int maxHealth;
        private int _currentHealth;
        [SerializeField] private Image healthBar;

        [SerializeField] private float _delayDeath;
        

        private void Start()
        {
            animator = GetComponent<Animator>();
            
            _targetZone = transform.parent.GetComponent<TargetZone>();
            _targetZone.AddEnemy(gameObject);
            
            _currentHealth = maxHealth;
        }

        public void TakeDamage()
        {
            _currentHealth--;

            healthBar.fillAmount = (float)_currentHealth / maxHealth;
            
            if (_currentHealth <= 0)
                StartCoroutine(Killed());
        }

        private IEnumerator Killed()
        {
            animator.enabled = false;
            canvas.SetActive(false);
            
            _targetZone.EnemyKilled(gameObject);

            yield return new WaitForSeconds(_delayDeath);
            
            Destroy(gameObject);
        }
    }
}
