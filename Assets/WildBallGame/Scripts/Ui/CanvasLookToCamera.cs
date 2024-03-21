using UnityEngine;

namespace WildBallGame.Scripts.Ui {
    public class CanvasLookToCamera : MonoBehaviour {
        private Camera _mainCamera;

        private void Start() {
            _mainCamera = Camera.main;
        }

        private void Update() {
            transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
        }
    }
}