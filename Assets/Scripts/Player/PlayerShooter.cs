using UnityEngine;
    
using Environment;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject shotPoint;

        private BulletsPool _bulletsPool;

        private void Start()
        {
            _bulletsPool = FindObjectOfType<BulletsPool>();
        }

        private void Update()
        {
            if (GoalManager.IsAttackMode()
                && Input.GetKeyDown(KeyCode.Mouse0))
                Shot();
        }

        private void Shot()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                SpawnBullet(hit.point);
            }
        }

        private void SpawnBullet(Vector3 targetPosition)
        {
            GameObject bullet = _bulletsPool.TryGetBullet();

            if (bullet != null)
            {
                bullet.transform.parent = null;
                bullet.transform.position = shotPoint.transform.position;
                bullet.transform.LookAt(targetPosition);
                bullet.GetComponent<BulletFlight>().StartMoving();
            }
        }
    }
}
