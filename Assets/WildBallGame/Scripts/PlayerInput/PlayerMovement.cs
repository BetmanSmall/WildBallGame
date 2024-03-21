using UnityEngine;
using WildBallGame.Scripts.Utils;

namespace WildBallGame.Scripts.PlayerInput {
    public class PlayerMovement : MonoBehaviour {
        // [SerializeField, Range(0f, 10f)]
        private float _speed = 10f;
        // [SerializeField, Range(1f, 200f)]
        private float _jumpPower = 10f;
        private Rigidbody _rigidbody;
        private ForceMode forceMode = ForceMode.Impulse;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement) {
            _rigidbody.AddForce(movement * _speed, ForceMode.Force);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.LeftControl)) {
                forceMode = EnumExtensions.Next(forceMode);
                Debug.Log("PlayerInput::Update(); -- forceMode:" + forceMode);
            }
        }

        public void JumpCharacter() {
            _rigidbody.AddForce(Vector3.up * _jumpPower, forceMode);
        }

        [ContextMenu("Reset values")]
        public void ResetValues() {
            _speed = 2f;
        }
    }
}