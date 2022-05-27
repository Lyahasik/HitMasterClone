using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        private GoalManager _goalManager;

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private GameObject _currentWaypoint;

        private bool _isMoving;

        private void OnEnable()
        {
            GoalManager.OnStartWorkingGoals += TargetAreaCleared;
            GoalManager.OnTargetAreaCleared += TargetAreaCleared;
        }

        private void Start()
        {
            StartCoroutine(TakeStartingPosition());
            
            _goalManager = FindObjectOfType<GoalManager>();
            
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        
        private void TargetAreaCleared()
        {
            _isMoving = true;
            _animator.SetBool("Moving", true);
            _currentWaypoint = _goalManager.GetNextWaypoint();
        }

        private IEnumerator TakeStartingPosition()
        {
            yield return new WaitForSeconds(0.1f);
            
            _currentWaypoint = _goalManager.GetNextWaypoint();

            transform.position = _currentWaypoint.transform.position;
            transform.rotation = _currentWaypoint.transform.rotation;
            
            CheckPointReached();
        }

        private void Update()
        {
            if (!_isMoving)
                return;
            
            CheckPointReached();
            MoveNextWaypoint();
        }

        private void CheckPointReached()
        {
            if (_currentWaypoint)
            {
                float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.transform.position);

                if (distanceToWaypoint < _navMeshAgent.stoppingDistance)
                {
                    _isMoving = false;
                    _animator.SetBool("Moving", false);
                    _currentWaypoint = null;
                    _goalManager.PlayerReachedPoint();
                }
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
