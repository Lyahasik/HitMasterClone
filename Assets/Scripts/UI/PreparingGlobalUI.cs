using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public class PreparingGlobalUI : MonoBehaviour
    {
        private Camera _camera;
        
        void Start()
        {
            _camera = Camera.main;
            
            GetComponent<Canvas>().worldCamera = _camera;
        }

        private void Update()
        {
            transform.LookAt(_camera.transform.position);
        }
    }
}
