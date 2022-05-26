using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapPanel : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            GoalManager.StartWorkingGoals();
        }
    }
}
