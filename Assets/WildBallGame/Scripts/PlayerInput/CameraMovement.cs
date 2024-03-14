using UnityEngine;
namespace WildBallGame.Scripts.PlayerInput {
    public class CameraMovement : MonoBehaviour {
        [SerializeField] private Transform playerTransform;
        private Vector3 _offset;

        private void Start() {
            _offset = transform.position - playerTransform.position;
        }

        private void FixedUpdate() {
            transform.position = playerTransform.position + _offset;
        }
    }
}