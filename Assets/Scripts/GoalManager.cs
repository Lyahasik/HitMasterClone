using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public static Action OnStartWorkingGoals;
    public static Action OnTargetAreaCleared;
    
    private static bool _isProgressedGame;
    private static bool _isAttackMode;
    
    public GameObject[] _waypoints;
    private int _currentWaypointId;
    
    public static void StartWorkingGoals()
    {
        if (_isProgressedGame)
            return;

        _isProgressedGame = true;
        OnStartWorkingGoals?.Invoke();
    }

    public static bool IsAttackMode()
    {
        return _isAttackMode;
    }
    
    public static void TargetAreaCleared()
    {
        OnTargetAreaCleared?.Invoke();
    }

    private void Update()
    {
        DisplayPointRelationships();
    }

    private void DisplayPointRelationships()
    {
        for (int i = 1; i < _waypoints.Length; i++)    
        {
            Debug.DrawLine(_waypoints[i - 1].transform.position, _waypoints[i].transform.position);
        }
    }
    
    public void PlayerReachedPoint()
    {
        _isAttackMode = true;
        _currentWaypointId++;
        
        if (_currentWaypointId >= _waypoints.Length)
        {
            ResetValues();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public GameObject GetNextWaypoint()
    {
        _isAttackMode = false;
        return _waypoints[_currentWaypointId];
    }

    private static void ResetValues()
    {
        _isProgressedGame = false;
        
        OnStartWorkingGoals = null;
        OnTargetAreaCleared = null;
    }
}
