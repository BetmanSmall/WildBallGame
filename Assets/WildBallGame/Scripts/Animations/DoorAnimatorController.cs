using UnityEngine;
namespace WildBallGame.Scripts.Animations {
    public class DoorAnimatorController : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject worldCanvas;
        private bool _doorIsOpen;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                worldCanvas.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player")) {
                worldCanvas.SetActive(false);
            }
        }

        private void OnTriggerStay(Collider other) {
            if (other.CompareTag("Player")) {
                if (!_doorIsOpen) {
                    if (Input.GetKeyDown(KeyCode.E)) {
                        _doorIsOpen = true;
                        animator.SetTrigger("OpenDoor");
                    }
                }
            }
        }
    }
}