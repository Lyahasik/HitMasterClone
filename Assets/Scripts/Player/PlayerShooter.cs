using UnityEngine;

using Enemy;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Shot();
        }

        private void Shot()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                LifeEnemy lifeEnemy = hit.collider.GetComponent<LifeEnemy>();
                
                if (lifeEnemy)
                    lifeEnemy.Killed();
            }
        }
    }
}
