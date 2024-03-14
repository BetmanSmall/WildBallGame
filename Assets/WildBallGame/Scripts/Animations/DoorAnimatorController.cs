using UnityEngine;
namespace WildBallGame.Scripts.Animations {
    public class DoorAnimatorController : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject worldCanvas;
        private bool _doorIsOpen;
        private bool _playerInTrigger;
        private const string AnimationOpenDoorString = "OpenDoor";

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
                worldCanvas.SetActive(true);
                _playerInTrigger = true;
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
                worldCanvas.SetActive(false);
                _playerInTrigger = false;
            }
        }

        private void Update() {
            if (_playerInTrigger && !_doorIsOpen) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    _doorIsOpen = true;
                    animator.SetTrigger(AnimationOpenDoorString);
                }
            }
        }
    }
}