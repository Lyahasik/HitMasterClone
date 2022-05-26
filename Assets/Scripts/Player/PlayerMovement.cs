using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        private GoalManager _goalManager;
        private Camera _camera;

        private NavMeshAgent _navMeshAgent;
        
        private GameObject _currentWaypoint;

        private void Start()
        {
            StartCoroutine(TakeStartingPosition());
            
            _goalManager = FindObjectOfType<GoalManager>();
            _camera = Camera.main;
            
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private IEnumerator TakeStartingPosition()
        {
            yield return new WaitForSeconds(0.1f);
            
            _currentWaypoint = _goalManager.TryGetNextWaypoint();

            transform.position = _currentWaypoint.transform.position;
            transform.rotation = _currentWaypoint.transform.rotation;
            
            CheckPointReached();
        }

        private void Update()
        {
            CheckPointReached();
            MoveNextWaypoint();
        }

        private void CheckPointReached()
        {
            if (_currentWaypoint)
            {
                float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.transform.position);
                
                if (distanceToWaypoint < _navMeshAgent.stoppingDistance)
                    _currentWaypoint = _goalManager.TryGetNextWaypoint();
            }
        }

        private void MoveNextWaypoint()
        {
            if (!_currentWaypoint)
                return;
            
            _navMeshAgent.SetDestination(_currentWaypoint.transform.position);
        }
    }
}
