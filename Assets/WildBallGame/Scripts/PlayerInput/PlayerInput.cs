using UnityEngine;
namespace WildBallGame.Scripts.PlayerInput {
    public class PlayerInput : MonoBehaviour {
        private const float _shiftSpeedIncrease = 2f;
        private Vector3 _movement = new Vector3();
        private PlayerMovement _playerMovement;
        private bool _jump;

        private void Awake() {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update() {
            float horizontal = Input.GetAxis(GlobalStringsVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringsVars.VERTICAL_AXIS);
            _movement.Set(horizontal, 0f, vertical);
            if (Input.GetKey(KeyCode.LeftShift)) {
                _movement *= _shiftSpeedIncrease;
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