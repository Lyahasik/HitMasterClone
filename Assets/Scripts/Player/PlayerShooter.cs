using UnityEngine;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject prefabBullet;
        [SerializeField] private GameObject shotPoint;
        
        private Vector3 shotDirection;
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
                GameObject gameObject = Instantiate(prefabBullet, shotPoint.transform.position, Quaternion.identity);
                gameObject.transform.LookAt(hit.point);
            }
        }
    }
}
