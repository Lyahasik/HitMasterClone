using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject[] _waypoints;

    private int _currentWaypointId;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return null;
        }

        Debug.Log(_currentWaypointId);
        GameObject waypoint = _waypoints[_currentWaypointId];
        _currentWaypointId++;
        
        return waypoint;
    }
}
