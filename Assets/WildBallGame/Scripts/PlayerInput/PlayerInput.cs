using UnityEngine;
namespace WildBallGame.Scripts.PlayerInput {
    public class PlayerInput : MonoBehaviour {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const float ShiftSpeedIncrease = 2f;
        private Vector3 _movement = new Vector3();
        private PlayerMovement _playerMovement;
        private bool _jump;

        private void Awake() {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update() {
            float horizontal = Input.GetAxis(HorizontalAxis);
            float vertical = Input.GetAxis(VerticalAxis);
            _movement.Set(horizontal, 0f, vertical);
            if (Input.GetKey(KeyCode.LeftShift)) {
                _movement *= ShiftSpeedIncrease;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                _jump = true;
            }
        }

        private void FixedUpdate() {
            _playerMovement.MoveCharacter(_movement);
            if (_jump) {
                _playerMovement.JumpCharacter();
                _jump = false;
            }
        }
    }
}