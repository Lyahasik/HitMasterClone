using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public static Action OnStartWorkingGoals;
    
    public GameObject[] _waypoints;

    private int _currentWaypointId;
    
    private static bool _isProgressed;

    public static void StartWorkingGoals()
    {
        if (_isProgressed)
            return;

        _isProgressed = true;
        OnStartWorkingGoals?.Invoke();
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

    public GameObject TryGetNextWaypoint()
    {
        if (_currentWaypointId >= _waypoints.Length)
        {
            ResetValues();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return null;
        }

        GameObject waypoint = _waypoints[_currentWaypointId];
        _currentWaypointId++;
        
        return waypoint;
    }

    private void ResetValues()
    {
        _isProgressed = false;
        
        OnStartWorkingGoals = null;
    }
}
