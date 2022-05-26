using UnityEngine;

namespace UI
{
    public class StartText : MonoBehaviour
    {
        private void OnEnable()
        {
            GoalManager.OnStartWorkingGoals += StartWorkingGoals;
        }

        private void OnDisable()
        {
            GoalManager.OnStartWorkingGoals -= StartWorkingGoals;
        }

        private void StartWorkingGoals()
        {
            Destroy(gameObject);
        }
    }
}
