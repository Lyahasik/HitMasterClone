using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapPanel : MonoBehaviour, IPointerDownHandler
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            GoalManager.StartWorkingGoals();
        }
    }
}
